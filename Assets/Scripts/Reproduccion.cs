using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduccion : MonoBehaviour   //Script de la habitación dormitorio para crear crías
{

    ConejosEnSala scriptSalas;
    public float tiempoNacimiento;
   

    public GameObject gazaposPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        scriptSalas = GetComponent<ConejosEnSala>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator NaceCrias() //Corrutina para que nazcan las crías, y se le guarde uno de los apellidos de los padres
    {
        yield return new WaitForSeconds(tiempoNacimiento);
        GameObject conejitoNuevo =  Instantiate(gazaposPrefab, transform.position, new Quaternion(0, 0, 0, transform.rotation.w));
        conejitoNuevo.GetComponent<CrecimientoBebe>().apellidoElegido = scriptSalas.apellidosDentro[Random.Range(0, 1)];
        Debug.Log("Cagando Crias");

        FindObjectOfType<AudioManager>().Play("PopUp");
    }

    void OnTriggerEnter2D(Collider2D col)       //Cuando hay dos personajes en la sala lanza la corrutina anterior
    {
        if (col.CompareTag("Conejos"))
        {
            if (scriptSalas.conejosDentro.Count == 2)
            {
                StartCoroutine(NaceCrias());
                
            }
        }
    }
    void OnTriggerExit2D(Collider2D col) //Cuando no hay dos personajes en sala se para la corrutina
    {
        if (scriptSalas.conejosDentro.Count < 2)
        {
            StopAllCoroutines();
        }
    }


    
}
