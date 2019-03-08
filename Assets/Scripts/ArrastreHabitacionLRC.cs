using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrastreHabitacionLRC : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocidad;
    public float velocidadTope;
    public Transform habitacionActual;
    public ConejosEnSala scriptSalas;
    bool fueraDeHabitacion;
    SpriteRenderer spritePJ;
    public static ArrastreHabitacionLRC instancia;
    Animator animPJ;

    
    public Vector2 vectorVelocidad;


    public LayerMask layerMask;
    GameObject golpeado;

    bool enCombate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spritePJ = GetComponent<SpriteRenderer>();
        animPJ = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 direction;
        if (spritePJ.flipX)
            direction = Vector2.right;
        else
            direction = Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x,(transform.position.y + 0.5f),transform.position.z), direction, 1, layerMask);





        if (hit)
        {
            Debug.DrawRay(new Vector3(transform.position.x,(transform.position.y + 0.5f),transform.position.z), direction * 1, Color.yellow);
            Debug.Log("Did Hit " + hit.transform.name);

            if (golpeado == null)
            {
                golpeado = hit.collider.gameObject;
                StartCoroutine(ConejoAtacando());                
            }
            
            enCombate = true;
            CancelInvoke("EscribirEnCuaderno");
            animPJ.SetBool("EnCombate",enCombate);
        }
        else
        {
            Debug.DrawRay(new Vector3(transform.position.x,(transform.position.y + 0.5f),transform.position.z), direction * 1, Color.white);
            Debug.Log("Did not Hit");
            golpeado = null;
            if (enCombate == true)
            {
                vectorVelocidad.x = 1;
                rb.AddForce(vectorVelocidad * velocidad);
            }
            enCombate = false;
            animPJ.SetBool("EnCombate", enCombate);
            StopAllCoroutines();
        }
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("HabitacionElectricidad")|| 
            col.gameObject.CompareTag("HabitacionAgua")|| 
            col.gameObject.CompareTag("HabitacionComida")|| 
            col.gameObject.CompareTag("HabitacionVeterinario")|| 
            col.gameObject.CompareTag("HabitacionDormitorio")|| 
            col.gameObject.CompareTag("HabitacionPuertaEntrada")|| 
            col.gameObject.CompareTag("Habitacion")||
            col.gameObject.CompareTag("HabitacionExpediciones"))
        {
            if (Mathf.Abs(rb.velocity.x) < velocidadTope)
            {
                rb.AddForce(vectorVelocidad * velocidad);
            }
            scriptSalas = col.GetComponent<ConejosEnSala>();
            
                if (scriptSalas.conejosDentro.Count < 3)
                {
                habitacionActual = col.transform;
                fueraDeHabitacion = false;
                }
            
           
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("HabitacionElectricidad")||
            col.gameObject.CompareTag("HabitacionComida")||
            col.gameObject.CompareTag("HabitacionAgua")||
            col.gameObject.CompareTag("HabitacionVeterinario")||
            col.gameObject.CompareTag("HabitacionDormitorio")||
            col.gameObject.CompareTag("HabitacionPuertaEntrada")||
            col.gameObject.CompareTag("HabitacionExpediciones"))
        {
            fueraDeHabitacion = true;
            rb.velocity = new Vector2(0,0);
        }
    }

    


    void EscribirEnCuaderno()
    {
        animPJ.SetBool("Escribir",true);
        PararMovimiento();
    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pared"))
        {
            velocidad = velocidad *-1;
            spritePJ.flipX = !spritePJ.flipX;
            Invoke("EscribirEnCuaderno", Random.Range(1f,2f));
        }
    }

    public void PararMovimiento()
    {
        vectorVelocidad.x = 0;
        Invoke("ReiniciarMovimiento", Random.Range(1f, 3f));
    }
    public void MorirConejo()
    {
        vectorVelocidad.x = 0;
        animPJ.SetTrigger("Morir");
        GetComponent<EstadisticasPJ>().felicidad = 0;


        GameObject[] conejos = GameObject.FindGameObjectsWithTag("Conejos");

        foreach(GameObject conejo in conejos)
        {
            conejo.GetComponent<EstadisticasPJ>().felicidad-= 10;
        }

        Destroy(gameObject, 5f);
    }
    public void RecibirDanoConejo()
    {
        
        animPJ.SetTrigger("Dano");
    }

    public void VuelveAndar()
    {
        if (!enCombate)
        {
            vectorVelocidad.x = 1;
            rb.AddForce(vectorVelocidad * velocidad);
        }
        
    }

    IEnumerator ConejoAtacando()
    {
        vectorVelocidad.x = 0;
        while (true)
        {
            if (golpeado != null)
            {
                animPJ.SetTrigger("Punetazo");
                golpeado.GetComponent<ZorroScript>().QuitaVida(3);
            }
            yield return new WaitForSeconds(2f);
        }

    }

    public void ReiniciarMovimiento()
    {
        animPJ.SetBool("Escribir",false);
        vectorVelocidad.x = 1;
        rb.AddForce(vectorVelocidad * velocidad);
        
    }

    private void OnMouseDrag()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.5f);

    }
    private void OnMouseUp()
    {
        if (fueraDeHabitacion)
        {
            transform.position = habitacionActual.position;
        }
    }


}
