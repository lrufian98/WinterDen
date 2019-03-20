using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneradorDeRecursos : MonoBehaviour
{
    bool dentroElectricidad = false;  //Bool para determinar si el personaje se encuentra en la habitación de electricidad
    bool dentroComida = false;
    bool dentroAgua = false;
    bool dentroVet = false;

    bool produciendo = false;   //Bool para determinar si el personaje está produciendo algún recurso
    public float tiempo = 1;    // Float para saber el tiempo que tardan los recursos en generarse
    public float tiempoVendas = 5;

    public int cantidadRecursosBaseGenerados;
    public int cantidadVendasGeneradas;

    public EstadisticasPJ statsPJ;

    public float tiempoExp;


    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
             
        
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("HabitacionElectricidad"))        //Cuando el personaje entra y está en la habitación de electricidad activa un bool que indica que está dentro de la habitación de electricidad
        {                                                               //y comienza a generar electricidad y a aumentar la experiencia de la estadística relacionada

            dentroElectricidad = true;
            if (!produciendo)
            {
                produciendo = true;
                StartCoroutine(generarRecursos());
                StartCoroutine(generarExperiencia());
            }

        }
        if (col.gameObject.CompareTag("HabitacionComida"))        //Cuando el personaje entra y está en la habitación de comida activa un bool que indica que está dentro de la habitación de comida
        {                                                         //y comienza a generar comida y a aumentar la experiencia de la estadística relacionada


            dentroComida = true;
            if (!produciendo)
            {
                produciendo = true;
                StartCoroutine(generarRecursos());
                StartCoroutine(generarExperiencia());
            }

        }
        if (col.gameObject.CompareTag("HabitacionAgua"))        //Cuando el personaje entra y está en la habitación de agua activa un bool que indica que está dentro de la habitación de agua
        {                                                               //y comienza a generar agua y a aumentar la experiencia de la estadística relacionada


            dentroAgua = true;
            if (!produciendo)
            {
                produciendo = true;
                StartCoroutine(generarRecursos());
                StartCoroutine(generarExperiencia());
            }

        }
        if (col.gameObject.CompareTag("HabitacionVeterinario"))         //Cuando el personaje entra y está en la habitación de vendas activa un bool que indica que está dentro de la habitación de vendas
        {                                                               //y comienza a generar vendas y a aumentar la experiencia de la estadística relacionada

            dentroVet = true;
            if(!produciendo)
            {
                produciendo = true;
                StartCoroutine(generarRecursos());
                StartCoroutine(generarExperiencia());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)             //detecta que el conejo ha salido de una habitación y desactiva todos los bools relacionados
    {
        if (
            col.gameObject.CompareTag("HabitacionElectricidad") || 
            col.gameObject.CompareTag("HabitacionComida") ||
            col.gameObject.CompareTag("HabitacionAgua") ||
            col.gameObject.CompareTag("HabitacionVeterinario")
            )        
        {
                                                                    
            dentroElectricidad = false;
            dentroComida = false;
            dentroAgua = false;
            dentroVet = false;
            StopAllCoroutines();
            produciendo = false;

        }
        
    }

    
    

    IEnumerator generarRecursos()  //Corrutina para que los conejos generen los recursos dependiendo de en que habtación se encuentren y generando más recursos cuanto más nivel tengan
    {
        while (produciendo)
        {
            if (dentroComida)
            {

                yield return new WaitForSeconds(tiempo);
                if (ControladorDeRecursos.comida < ControladorDeRecursos.capacidadComida)
                {
                    ControladorDeRecursos.comida = ControladorDeRecursos.comida + cantidadRecursosBaseGenerados + statsPJ.aptitud;
                }

            }
            else if (dentroElectricidad)
            {
                yield return new WaitForSeconds(tiempo);
                if (ControladorDeRecursos.electricidad < ControladorDeRecursos.capacidadElectricidad)
                {
                    ControladorDeRecursos.electricidad = ControladorDeRecursos.electricidad + cantidadRecursosBaseGenerados + statsPJ.energia;
                }
            }
            else if (dentroAgua)
            {
                yield return new WaitForSeconds(tiempo);
                if (ControladorDeRecursos.agua < ControladorDeRecursos.capacidadAgua)
                {
                    ControladorDeRecursos.agua = ControladorDeRecursos.agua + cantidadRecursosBaseGenerados + statsPJ.tecnica;
                }

            }
            else if (dentroVet)
            {
                yield return new WaitForSeconds(tiempoVendas);
                if(ControladorDeRecursos.vendas < ControladorDeRecursos.capacidadVendas)
                {
                    ControladorDeRecursos.vendas = ControladorDeRecursos.vendas + cantidadVendasGeneradas + statsPJ.inteligencia;
                }
            }
            else
            {
                produciendo = false;
            }
        }
    }
    IEnumerator generarExperiencia()    //Corrutina para que cuando un conejo se encuentre dentro de cada habitación aumente la experiencia de la estadística relacionada
    {
        while (produciendo)
        {
            if (dentroComida)
            {

                yield return new WaitForSeconds(tiempoExp);
                statsPJ.expAp++;

            }
            else if (dentroElectricidad)
            {
                yield return new WaitForSeconds(tiempoExp);
                statsPJ.expEn++;
            }
            else if (dentroAgua)
            {
                yield return new WaitForSeconds(tiempoExp);
                statsPJ.expTec++;

            }
            else if (dentroVet)
            {
                yield return new WaitForSeconds(tiempoExp);
                statsPJ.expInt++;
            }
            else
            {
                produciendo = false;
            }
        }
    }
    
}
