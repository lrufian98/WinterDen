using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorroScript : MonoBehaviour
{
    public int vidaZorro = 10;
    public float numeroConejos = 0f;
    Animator animZorro;

    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        animZorro = GetComponent<Animator>();
    }

    private void Awake()
    {
        numeroConejos = GameObject.FindGameObjectsWithTag("Conejos").Length + GameObject.FindGameObjectsWithTag("BebesConejos").Length;
        vidaZorro = vidaZorro + Mathf.RoundToInt(numeroConejos/5);
    }


    void SaqueoDinero()
    {
        ControladorDeRecursos.dinero += Random.Range(25, 50);
    }

    public void QuitaVida(int cantidad)
    {
        vidaZorro -= cantidad;
        RecibirDanoZorro();

        if (vidaZorro <= 0)
        {
            MorirZorro();
        }
    }

    public void RecibirDanoZorro()
    {
        GetComponent<movimientoZorro>().velocidad = 0;
        animZorro.SetTrigger("Dano");
    }

    public void MorirZorro()
    {
        SaqueoDinero();
        Destroy(gameObject, 1f);
        animZorro.SetTrigger("Morir");
    }



}
