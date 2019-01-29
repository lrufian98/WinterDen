using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneradorDeRecursos : MonoBehaviour
{
    bool dentroElectricidad = false;  //Bool para determinar si el personaje se encuentra en la habitación de electricidad
    bool produciendo = false;   //Bool para determinar si el personaje está produciendo algún recurso
    public float tiempo = 1;    // Float para saber el tiempo que tardan los recursos en generarse
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dentroElectricidad)         //Condicional dentro de update para que se sepa siempre si el personaje está dentro de la habitación de electricidad
        {
            if (!produciendo)           //Si el personaje no está produciendo ningún recurso, activa el bool "produciendo" y comienza la corutina que produce electricidad
            {
                produciendo = true;
                StartCoroutine(sumaElectricidad());
                

            }
        }
        else                            // Si no está dentro de la habitación, se detienen todas la corutinas que se estén ejecutando en este personaje, y desactiva el bool que indica que se están produciendo recursos
        {
            StopAllCoroutines();
            produciendo = false;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("HabitacionElectricidad"))        //Cuando el personaje entra y está en la habitación de electricidad activa un bool que indica que está dentro de la habitación de electricidad
        {

            dentroElectricidad = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D col)             
    {
        if (col.gameObject.CompareTag("HabitacionElectricidad"))        //Cuando el personaje sale de la habitación de electricidad desactiva un bool que indica que está dentro de la habitación de electricidad
        {
                                                                    
            dentroElectricidad = false;

        }
    }

    IEnumerator sumaElectricidad()                                      //Corutina para generar el recurso de electricidad mientras la cantidad de electricidad almacenada sea menor a la capacidad de almacenaje de electricidad
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
