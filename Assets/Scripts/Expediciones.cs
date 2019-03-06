using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Expediciones : MonoBehaviour
{
    public GameObject PosicionExpediciones;
    
    public Vector3 puntoOrigen;
    public GameObject HabitacionEntrada;
    public GameObject menuExpediciones;
    public Text textoExpediciones;
    Animator animacionMenuExpediciones;
    
    


    void Awake()
    {
        HabitacionEntrada = GameObject.Find("Habitacion Puerta Entrada");
        PosicionExpediciones = GameObject.Find("HabitacionDelOlvido");
        menuExpediciones = GameObject.Find("panelExpediciones");
        textoExpediciones = GameObject.Find("historia").GetComponent<Text>();

    }
    private void Start()
    {
        animacionMenuExpediciones = menuExpediciones.GetComponent<Animator>();
    }

    public void OnMouseDown()
    {
        puntoOrigen = gameObject.transform.position;
        Debug.Log("Habitación Guardada");
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("HabitacionExpediciones"))
        {
            transform.position = PosicionExpediciones.transform.position;
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("HabitacionDelOlvido"))
        {
            Debug.Log("HabitaciónDelOlvido");
            Invoke("DeVuelta", Random.Range(2f,3f));
        }
    }

    void DeVuelta()
    {
        gameObject.transform.position = HabitacionEntrada.transform.position;
        Debug.Log("VoyDeVuelta");
        Recompensa();
        
    }

    void Recompensa()
    {
        int resultado = Random.Range(1, 5);

        switch (resultado)
        { 

            case 1 : //bajo
                ControladorDeRecursos.dinero = ControladorDeRecursos.dinero  + Random.Range(20, 30);
                Debug.Log("VoyDeVueltaMal");
                Debug.Log(ControladorDeRecursos.dinero);
                animacionMenuExpediciones.SetBool("MenuActivo", true);
                textoExpediciones.text =
                    "Salgo de la base." + "\n\r"
                    + "Le doy una patada a una manzana podrida." + "\n\r"
                    + "Me asusto con un ruido en un arbusto." + "\n\r"
                    + "Era solo el viento." + "\n\r"
                    + "Prosigo mi camino." + "\n\r"
                    + " " + "\n\r"
                    + "He encontrado un objeto grande y brillante." + "\n\r"
                    + "Parecía de valor pero pesa demasiado." + "\n\r"
                    + " " + "\n\r"
                    + "Me he encontrado con una mofeta." + "\n\r"
                    + "No estaba de humor y me ha dado una paliza." + "\n\r"
                    + "Pido disculpas por si arreglo algo y sigo hacia delante." + "\n\r"
                    + "Mejor no haber salido hoy." + "\n\r"
                    + " " + "\n\r"
                    + "¡Hay varias zanahorias en el suelo!" + "\n\r"
                    + "Eran de un oso que ha salido detrás de mí." + "\n\r"
                    + "Me ha dado tiempo a coger alguna." + "\n\r"
                    + " " + "\n\r"
                    + "Acabo de llegar a la base, por suerte sano y salvo.";
                break;
               
            case 2 : //medio
                ControladorDeRecursos.dinero = ControladorDeRecursos.dinero + Random.Range(200, 300);
                Debug.Log("VoyDeVueltaNormal");
                Debug.Log(ControladorDeRecursos.dinero);
                animacionMenuExpediciones.SetBool("MenuActivo", true);
                textoExpediciones.text =
                 "Salgo de la base." + "\n\r"
                 + "Le doy una patada a una manzana podrida." + "\n\r"
                 + "Me asusto con un ruido en un arbusto." + "\n\r"
                 + "Era solo el viento." + "\n\r"
                 + "Prosigo mi camino." + "\n\r"
                 + " " + "\n\r"
                 + "He encontrado un objeto grande y brillante." + "\n\r"
                 + "Parecía de valor pero pesa demasiado." + "\n\r"
                 + " " + "\n\r"
                 + "Me he encontrado con una mofeta." + "\n\r"
                 + "No estaba de humor y me ha dado una paliza." + "\n\r"
                 + "Pido disculpas por si arreglo algo y sigo hacia delante." + "\n\r"
                 + "Mejor no haber salido hoy." + "\n\r"
                 + " " + "\n\r"
                 + "¡Hay varias zanahorias en el suelo!" + "\n\r"
                 + "Eran de un oso que ha salido detrás de mí." + "\n\r"
                 + "Me ha dado tiempo a coger alguna." + "\n\r"
                 + " " + "\n\r"
                 + "Acabo de llegar a la base, por suerte sano y salvo.";
                break;
            case 3 : //morir
                Destroy(gameObject);
                Debug.Log("NoVoyDeVuelta");
                animacionMenuExpediciones.SetBool("MenuActivo", true);
                textoExpediciones.text =
                 "Salgo de la base." + "\n\r"
                 + "Le doy una patada a una manzana podrida." + "\n\r"
                 + "Me asusto con un ruido en un arbusto." + "\n\r"
                 + "Era solo el viento." + "\n\r"
                 + "Prosigo mi camino." + "\n\r"
                 + " " + "\n\r"
                 + "He encontrado un objeto grande y brillante." + "\n\r"
                 + "Parecía de valor pero pesa demasiado." + "\n\r"
                 + " " + "\n\r"
                 + "Me he encontrado con una mofeta." + "\n\r"
                 + "No estaba de humor y me ha dado una paliza." + "\n\r"
                 + "Pido disculpas por si arreglo algo y sigo hacia delante." + "\n\r"
                 + "Mejor no haber salido hoy." + "\n\r"
                 + " " + "\n\r"
                 + "¡Hay varias zanahorias en el suelo!" + "\n\r"
                 + "Eran de un oso que ha salido detrás de mí." + "\n\r"
                 + "Me ha dado tiempo a coger alguna." + "\n\r"
                 + " " + "\n\r"
                 + "Acabo de llegar a la base, por suerte sano y salvo.";


                break;

            case 4 : //alto
                ControladorDeRecursos.dinero = ControladorDeRecursos.dinero + Random.Range(2000, 3000);
                Debug.Log("VoyDeVueltaChuchi");
                Debug.Log(ControladorDeRecursos.dinero);
                animacionMenuExpediciones.SetBool("MenuActivo", true);
                textoExpediciones.text =
                              "Salgo de la base." + "\n\r"
                              + "Le doy una patada a una manzana podrida." + "\n\r"
                              + "Me asusto con un ruido en un arbusto." + "\n\r"
                              + "Era solo el viento." + "\n\r"
                              + "Prosigo mi camino." + "\n\r"
                              + "..." + "\n\r"
                              + "He encontrado un objeto grande y brillante." + "\n\r"
                              + "Parecía de valor pero pesa demasiado." + "\n\r"
                              + "..." + "\n\r"
                              + "Me he encontrado con una mofeta." + "\n\r"
                              + "No estaba de humor y me ha dado una paliza." + "\n\r"
                              + "Pido disculpas por si arreglo algo y sigo hacia delante." + "\n\r"
                              + "Mejor no haber salido hoy." + "\n\r"
                              + "..." + "\n\r"
                              + "¡Hay varias zanahorias en el suelo!" + "\n\r"
                              + "Eran de un oso que ha salido detrás de mí." + "\n\r"
                              + "Me ha dado tiempo a coger alguna." + "\n\r"
                              + "..." + "\n\r"
                              + "Acabo de llegar a la base, por suerte sano y salvo.";

                break;

        }


    }








}
