using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConejosEnSala : MonoBehaviour
{

    public List<GameObject> conejosDentro;

    //public bool salaLlena = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if (!salaLlena)
        //{
            if (col.CompareTag("Conejos"))
            {
                conejosDentro.Add(col.gameObject);
               // if(conejosDentro.Count == 2)
               // {
                 //   salaLlena = true;
               // }
            }
        //}
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Conejos"))
        {

            //if (conejosDentro.Count <= 2 && conejosDentro.Contains(col.gameObject))
            //{
                conejosDentro.Remove(col.gameObject);
               // salaLlena = false;
           // }
            
        }
    }
}
