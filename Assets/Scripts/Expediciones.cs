using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expediciones : MonoBehaviour
{
    public GameObject PosicionExpediciones;
    
    public Vector3 puntoOrigen;
    public GameObject HabitacionEntrada;


    void Awake()
    {
        HabitacionEntrada = GameObject.Find("Habitacion Puerta Entrada");
        PosicionExpediciones = GameObject.Find("HabitacionDelOlvido");
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

            case 1 :
                ControladorDeRecursos.dinero = ControladorDeRecursos.dinero  + Random.Range(20, 30);
                Debug.Log("VoyDeVueltaMal");
                Debug.Log(ControladorDeRecursos.dinero);
                break;
               
            case 2 :
                ControladorDeRecursos.dinero = ControladorDeRecursos.dinero + Random.Range(200, 300);
                Debug.Log("VoyDeVueltaNormal");
                Debug.Log(ControladorDeRecursos.dinero);
                break;
            case 3 :
                Destroy(gameObject);
                Debug.Log("NoVoyDeVuelta");
                break;

            case 4 :
                ControladorDeRecursos.dinero = ControladorDeRecursos.dinero + Random.Range(2000, 3000);
                Debug.Log("VoyDeVueltaChuchi");
                Debug.Log(ControladorDeRecursos.dinero);
                break;

        }


    }








}
