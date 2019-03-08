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
    public Text textoRecompensa;

    int mal;
    int medio;
    int buena;

    void Awake()
    {
        HabitacionEntrada = GameObject.Find("Habitacion Puerta Entrada");
        PosicionExpediciones = GameObject.Find("HabitacionDelOlvido");
        menuExpediciones = GameObject.Find("panelExpediciones");
        textoExpediciones = GameObject.Find("historia").GetComponent<Text>();
        textoRecompensa = GameObject.Find("ganancia").GetComponent<Text>();
        mal = Random.Range(20, 30);
        medio = Random.Range(200, 300);
        buena = Random.Range(2000, 3000);
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
                ControladorDeRecursos.dinero = ControladorDeRecursos.dinero  + mal;
                Debug.Log("VoyDeVueltaMal");
                Debug.Log(ControladorDeRecursos.dinero);
                animacionMenuExpediciones.SetBool("MenuActivo", true);
                textoRecompensa.text = mal.ToString();
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
                ControladorDeRecursos.dinero = ControladorDeRecursos.dinero + medio;
                Debug.Log("VoyDeVueltaNormal");
                Debug.Log(ControladorDeRecursos.dinero);
                animacionMenuExpediciones.SetBool("MenuActivo", true);
                textoRecompensa.text = medio.ToString();
                textoExpediciones.text = 
                 "Salgo de la base." + "\n\r"
                 + "Le doy una patada a una zanahoria." + "\n\r"
                 + "Busco si hay mas en un arbusto cercano." + "\n\r"
                 + "Encuentro algunas mas." + "\n\r"
                 + "Prosigo mi camino." + "\n\r"
                 + " " + "\n\r"
                 + "He encontrado un objeto misterioso." + "\n\r"
                 + "Parece que tiene poco valor pero me lo llevo." + "\n\r"
                 + " " + "\n\r"
                 + "Me he encontrado con una mofeta." + "\n\r"
                 + "hemos tratado de comunicarnos un poco." + "\n\r"
                 + "Terminamos la comunicación y me da algunas zanahorias." + "\n\r"
                 + "Hoy me he llevado una amiga nueva." + "\n\r"
                 + " " + "\n\r"
                 + "¡Hay varias zanahorias en el suelo!" + "\n\r"
                 + "Hay algunas podridas pero he salvado varias." + "\n\r"
                 + "Volvere a la base con un botín decente." + "\n\r"
                 + " " + "\n\r"
                 + "Acabo de llegar a la base sano y salvo.";
                break;
            case 3 : //morir
                Destroy(gameObject);
                Debug.Log("NoVoyDeVuelta");
                animacionMenuExpediciones.SetBool("MenuActivo", true);
                textoExpediciones.text = 
                 "Salgo de la base." + "\n\r"
                 + "Le doy una patada a una piedra y me hago daño en el pie." + "\n\r"
                 + "Me asusto con un ruido en un arbusto." + "\n\r"
                 + "Era un zorro escondido." + "\n\r"
                 + "Salgo corriendo." + "\n\r"
                 + " " + "\n\r"
                 + "Me ha caido una manzana en la cabeza." + "\n\r"
                 + "Le doy un bocado pero tenia gusanos dentro, PUAG!." + "\n\r"
                 + " " + "\n\r"
                 + "El zorro de antes vuelve a por mi." + "\n\r"
                 + "Me escondo tras un arbol." + "\n\r"
                 + "Ha llamado a dos zorros mas y me intentan encontrar." + "\n\r"
                 + "Tengo miedo, creo que no salgo de esta" + "\n\r"
                 + " " + "\n\r"
                 + "PARECE QUE EL CONEJO MURIÓ"; 


                break;

            case 4 : //alto
                ControladorDeRecursos.dinero = ControladorDeRecursos.dinero + buena;
                Debug.Log("VoyDeVueltaChuchi");
                Debug.Log(ControladorDeRecursos.dinero);
                animacionMenuExpediciones.SetBool("MenuActivo", true);
                textoRecompensa.text = buena.ToString();
                textoExpediciones.text =
                              "Salgo de la base." + "\n\r"
                              + "¡Encuentro una zanahoria nada mas salir! parece que sera un buen dia." + "\n\r"
                              + "Hay mas en una zona cercana." + "\n\r"
                              + "Recojo bastantes para poder cojer mas cosas despues." + "\n\r"
                              + "Prosigo mi camino." + "\n\r"
                              + "..." + "\n\r"
                              + "He encontrado un objeto grande y brillante." + "\n\r"
                              + "Creo un trineo con 2 ramas cercanas y me lo llevo." + "\n\r"
                              + "..." + "\n\r"
                              + "Me he encontrado con una mofeta." + "\n\r"
                              + "Resulta ser el rey de las mofetas." + "\n\r"
                              + "Me invita a un gran banquete en honor a nuestro encuentro." + "\n\r"
                              + "Me llevo las zanahorias sobrantes,¡que gran dia! ." + "\n\r"
                              + "..." + "\n\r"
                              + "¡Hay varias zanahorias en el suelo!" + "\n\r"
                              + "Tiro el objeto extraño del trineo para llenarlo de zanahoria" + "\n\r"
                              + "Mejor un saco de zanahorias que un objeto extraño." + "\n\r"
                              + "..." + "\n\r"
                              + "Acabo de llegar a la base, todos celebran mi llegada.";

                break;

        }


    }








}
