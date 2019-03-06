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

<<<<<<< HEAD
=======
    void SaqueoDinero()
    {
        ControladorDeRecursos.dinero += Random.Range(25, 200);
    }
>>>>>>> a06df21601ba6fb6dfcb9a5d55588a4a45b8c1f3

    

}
