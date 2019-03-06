using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorroScript : MonoBehaviour
{
    public int vidaZorro = 10;
    public float numeroConejos = 0f; 

    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        numeroConejos = GameObject.FindGameObjectsWithTag("Conejos").Length + GameObject.FindGameObjectsWithTag("BebesConejos").Length;
        vidaZorro = vidaZorro + Mathf.RoundToInt(numeroConejos/5);
    }


    

}
