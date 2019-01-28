using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneradorDeRecursos : MonoBehaviour
{
    bool dentroElectricidad = false;
    bool produciendo = false;
    public float tiempo = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dentroElectricidad)
        {
            if (!produciendo)
            {
                produciendo = true;
                StartCoroutine(sumaElectricidad());
                

            }
        }
        else
        {
            StopAllCoroutines();
            produciendo = false;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("HabitacionElectricidad"))
        {

            dentroElectricidad = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("HabitacionElectricidad"))
        {

            dentroElectricidad = false;

        }
    }

    IEnumerator sumaElectricidad()
    {
        while (produciendo) { 
            yield return new WaitForSeconds(tiempo);
            if (ControladorDeRecursos.electricidad < ControladorDeRecursos.capacidadElectricidad)
            {
                ControladorDeRecursos.electricidad++;
            }
        }
    }
}
