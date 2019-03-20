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
    {                                                       //accedemos a los componentes                        
        rb = GetComponent<Rigidbody2D>();
        spritePJ = GetComponent<SpriteRenderer>();
        animPJ = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 direction;                  //Vector direccion que apunta a donde esté andando el personaje
        if (spritePJ.flipX)
            direction = Vector2.right;
        else
            direction = Vector2.left;
                                                        //raycast para detectar a los zorros y combatir
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

    private void OnTriggerStay2D(Collider2D col)                //TriggerStay para detectar en que habitacion se encuentra cada personaje y guarda el gameobject
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


    private void OnTriggerExit2D(Collider2D col)            //TriggerExit para detectar que el personaje se encuentra fuera de una habitación
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

    


    void EscribirEnCuaderno()       //función que ejecuta la animación de escribir y lanza una función
    {
        animPJ.SetBool("Escribir",true);
        PararMovimiento();
    }



    private void OnCollisionEnter2D(Collision2D col)        //CollisionEnter para detectar que ha chocado con una pared de habitación, darse la vuelta y llamar a la función de escribir
    {
        if (col.gameObject.CompareTag("Pared"))
        {
            velocidad = velocidad *-1;
            spritePJ.flipX = !spritePJ.flipX;
            Invoke("EscribirEnCuaderno", Random.Range(1f,2f));
        }
    }

    public void PararMovimiento()               //función que para al personaje y ejecuta en un rango aleatorio de tiempo la funcióon que reinicia el movimiento
    {
        vectorVelocidad.x = 0;
        Invoke("ReiniciarMovimiento", Random.Range(1f, 3f));
    }
    public void MorirConejo()                 //función de morir
    {
        vectorVelocidad.x = 0;
        animPJ.SetTrigger("Morir");                     //reducimos velocidad a 0, lanzamos animación de morir y baja su felicidad a 0
        GetComponent<EstadisticasPJ>().felicidad = 0;


        GameObject[] conejos = GameObject.FindGameObjectsWithTag("Conejos");

        foreach(GameObject conejo in conejos)                                   //Accede a la felicidad de cada uno de los conejos y les resta 10 de felicidad
        {
            conejo.GetComponent<EstadisticasPJ>().felicidad-= 10;               
        }
        scriptSalas.conejosDentro.Remove(gameObject);
        scriptSalas.apellidosDentro.Remove(GetComponent<EstadisticasPJ>().apellido);        //elimina al personaje de la lista de personajes de dentro de cada habitacion
        scriptSalas.NombresDentro.Remove(GetComponent<EstadisticasPJ>().nombre);
        rb.isKinematic = true;
        Destroy(gameObject, 5f);                
    }
    public void RecibirDanoConejo()         //Función de recibir daño, ejecuta la animación y reproduce el sonido
    {
        
        animPJ.SetTrigger("Dano");          

        FindObjectOfType<AudioManager>().Play("DañoConejo");
    }

    public void VuelveAndar()           //función que reninicia el movimiento cuando el personaje sale de combate
    {
        if (!enCombate)
        {
            vectorVelocidad.x = 1;
            rb.AddForce(vectorVelocidad * velocidad);
        }
        
    }

    IEnumerator ConejoAtacando()        //Corrutina de combate, en función de si el raycast detecta a un enemigo, accede a su script de vida y le quita
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

    private void OnMouseDrag()          //cuando se arrastra el dedo/raton, se lleva al personaje
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.5f);

    }
    private void OnMouseUp()     //si se suelta al personaje arrastrado fuera de una habitación, vuelve a la última en la que estuvo
    {
        if (fueraDeHabitacion)
        {
            transform.position = habitacionActual.position;
        }
    }


}
