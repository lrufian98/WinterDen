using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorroScript : MonoBehaviour  //Script que gestiona la vida de los zorros
{
    public int vidaZorro = 10;
    public float numeroConejos = 0f;
    Animator animZorro;

    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        animZorro = GetComponent<Animator>();
    }

    private void Awake() //En función del numero de conejos los zorros tienen más vida
    {
        numeroConejos = GameObject.FindGameObjectsWithTag("Conejos").Length + GameObject.FindGameObjectsWithTag("BebesConejos").Length;
        vidaZorro = vidaZorro + Mathf.RoundToInt(numeroConejos/5);
    }


    void SaqueoDinero()
    {
        ControladorDeRecursos.dinero += Random.Range(25, 50);
    }

    public void QuitaVida(int cantidad) //Script para recibir daño de combate
    {
        vidaZorro -= cantidad;
        RecibirDanoZorro();

        if (vidaZorro <= 0)
        {
            MorirZorro();
        }
    }

    public void RecibirDanoZorro()      //se lanza la animacion de recibir daño
    {
        GetComponent<movimientoZorro>().velocidad = 0;
        animZorro.SetTrigger("Dano");
    }

    public void MorirZorro() //se lanza la animación de morir y se añade una cantidad de dinero
    {
        SaqueoDinero();
        Destroy(gameObject, 1f);
        animZorro.SetTrigger("Morir");

        FindObjectOfType<AudioManager>().Play("MuerteZorro");
    }



}
