using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPuertaEntrada : MonoBehaviour
{

    public static int vidaPuerta = 20;
    public bool regeneracion = false;
    public Collider2D puertaAbierta;

    // Start is called before the first frame update
    void Start()
    {
        puertaAbierta = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaPuerta <= 0 & regeneracion == false){

            puertaAbierta.enabled = false;
            regeneracion = true;
            Invoke("RegenerandoVida", 10f);
        } 
    }

    void RegenerandoVida()
    {

        vidaPuerta = 20;
        regeneracion = false;
        puertaAbierta.enabled = true;
    }

}
