using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expediciones : MonoBehaviour
{
    public GameObject PosicionExpediciones;
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("HabitacionExpediciones"))
        {
            transform.position = PosicionExpediciones.transform.position;
        }
    }
}
