using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrastreHabitacionLRC : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocidad;
    public float velocidadTope;
    public Transform habitacionActual;
    bool fueraDeHabitacion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Habitacion"))
        {
            if (Mathf.Abs(rb.velocity.x) < velocidadTope)
            {
                rb.AddForce(new Vector2(1, 0) * velocidad);
            }
            habitacionActual = col.transform;
            fueraDeHabitacion = false;
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Habitacion"))
        {
            fueraDeHabitacion = true;
            rb.velocity = new Vector2(0,0);
        }
    }






    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pared"))
        {
            velocidad = velocidad *-1;
        }
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
