using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduccion : MonoBehaviour
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
    IEnumerator NaceCrias()
    {
        yield return new WaitForSeconds(tiempoNacimiento);
        Instantiate(gazaposPrefab, transform.position, new Quaternion(0, 0, 0, transform.rotation.w));
        Debug.Log("Cagando Crias");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Conejos"))
        {
            if (scriptSalas.conejosDentro.Count == 2)
            {
                StartCoroutine(NaceCrias());
                
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (scriptSalas.conejosDentro.Count < 2)
        {
            StopAllCoroutines();
        }
    }


    
}
