using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConejosEnSala : MonoBehaviour
{
    float tiempoGastoElectricidad = 15;

    public List<GameObject> conejosDentro;
    public List<string> apellidosDentro;
    public List<string> NombresDentro;


    //public bool salaLlena = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GastoElectricidad()); //comienza la corrutina de gastar electricidad
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    void OnTriggerEnter2D(Collider2D col)           //trigger para detectar los conejos de la sala, guardando su gameobject y sus nombres y apellidos en listas
    {
        if (col.CompareTag("Conejos")) 
        {
            conejosDentro.Add(col.gameObject);
            apellidosDentro.Add(col.gameObject.GetComponent<EstadisticasPJ>().apellido);
            NombresDentro.Add(col.gameObject.GetComponent<EstadisticasPJ>().nombre);
        }  
    }

    void OnTriggerExit2D(Collider2D col)            //trigger para detectar los conejos que salen de la sala, eliminando su gameobject y sus nombres y apellidos de las listas
    {
        if (col.CompareTag("Conejos"))             
        {            
            conejosDentro.Remove(col.gameObject);
            apellidosDentro.Remove(col.gameObject.GetComponent<EstadisticasPJ>().apellido);
            NombresDentro.Remove(col.gameObject.GetComponent<EstadisticasPJ>().nombre);
        }
    }
    IEnumerator GastoElectricidad()                 //Corrutina que gasta electricidad
    {
        while (true)
        {
            Debug.Log("GastoElectricidad");
            if (ControladorDeRecursos.electricidad > 0)
            {
                ControladorDeRecursos.electricidad-= 2;
            }

            yield return new WaitForSeconds(tiempoGastoElectricidad);
        }



    }

}
