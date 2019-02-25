using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expediciones : MonoBehaviour
{
    public GameObject PosicionExpediciones;
    
    Transform puntoOrigen;

    public void OnMouseDown()
    {
        puntoOrigen = gameObject.transform;
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
            Debug.Log("Habitación Guardada");
            Invoke("DeVuelta", Random.Range(2f, 3f));
        }
    }

    void DeVuelta()
    {
        gameObject.transform.position = puntoOrigen.position;
    }









}
