using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConejosEnSala : MonoBehaviour
{

    public List<GameObject> conejosDentro;
    public List<string> apellidosDentro;

    //public bool salaLlena = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GastoElectricidad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Conejos")) 
        {
            conejosDentro.Add(col.gameObject);
            apellidosDentro.Add(col.gameObject.GetComponent<EstadisticasPJ>().apellido);               
        }  
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Conejos"))
        {            
            conejosDentro.Remove(col.gameObject);
            apellidosDentro.Remove(col.gameObject.GetComponent<EstadisticasPJ>().apellido);
        }
    }
    IEnumerator GastoElectricidad()
    {
        while (true)
        {
            Debug.Log("GastoElectricidad");
            if (ControladorDeRecursos.electricidad > 0)
            {
                ControladorDeRecursos.electricidad--;
            }

            yield return new WaitForSeconds(5f);
        }



    }

}
