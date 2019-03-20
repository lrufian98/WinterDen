using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{

    public LayerMask layerMask;
    public LayerMask layerMask2;

    GameObject golpeado;
    public float danoEnemigo;
    Animator animZorro;
    bool enCombate;
    SpriteRenderer sprZorro;

    // Start is called before the first frame update
    void Start()
    {
        animZorro = GetComponent<Animator>();
        sprZorro = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction;                                  //Vector direccion que apunta a donde esté andando el personaje
        if (sprZorro.flipX)
        {
            direction = Vector2.right;
        }
        else
            direction = Vector2.left;
                                                            //Dos raycast para que los zorros ataquen a los conejos y a la puerta de la madriguera
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, direction, 1, layerMask2);




        if (hit)
        {
            Debug.DrawRay(transform.position, direction * 1, Color.yellow);
            Debug.Log("Did Hit " + hit.transform.name);

            if (golpeado == null)
            {
                StartCoroutine(Atacando());
                golpeado = hit.collider.gameObject;
                
            }
            enCombate = true;
            GetComponent<movimientoZorro>().velocidad = 0;
            animZorro.SetBool("EnCombate", enCombate);

        }
        else if (hit2)
        {
            Debug.DrawRay(transform.position, direction * 1, Color.yellow);
            Debug.Log("Did Hit " + hit2.transform.name);

            if (golpeado == null)
            {
                StartCoroutine(Atacando());
                golpeado = hit2.collider.gameObject;

            }
            enCombate = true;
            GetComponent<movimientoZorro>().velocidad = 0;
            animZorro.SetBool("EnCombate", enCombate);
        }
        else
        {
            Debug.DrawRay(transform.position, direction * 1, Color.white);
            Debug.Log("Did not Hit");
            golpeado = null;
            enCombate = false;
            GetComponent<movimientoZorro>().velocidad = 1;
            animZorro.SetBool("EnCombate", enCombate);
            StopAllCoroutines();

        }
    }


    IEnumerator Atacando()              //Corrutina de combate, en función de si el raycast detecta a un conejo/puerta, accede a su script de vida y le quita un poco
    {
        while (true)
        {
            if (golpeado != null)
            {
                if (golpeado.gameObject.CompareTag("Conejos"))
                {
                    animZorro.SetTrigger("Ataque");
                    golpeado.GetComponent<EstadisticasPJ>().QuitaVida(danoEnemigo);
                }
                if (golpeado.gameObject.CompareTag("PortonEntrada"))
                {
                    animZorro.SetTrigger("Ataque");
                    VidaPuertaEntrada.vidaPuerta--;
                }
                
            }
            yield return new WaitForSeconds(2f);
        }

    }
}
