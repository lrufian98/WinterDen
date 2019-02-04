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
        {

            dentroElectricidad = true;
            if (!produciendo)
            {
                produciendo = true;
                StartCoroutine(generarRecursos());
                StartCoroutine(generarExperiencia());
            }

        }
        if (col.gameObject.CompareTag("HabitacionComida"))        //Cuando el personaje entra y está en la habitación de comida activa un bool que indica que está dentro de la habitación de comida
        {

            dentroComida = true;
            if (!produciendo)
            {
                produciendo = true;
                StartCoroutine(generarRecursos());
                StartCoroutine(generarExperiencia());
            }

        }
        if (col.gameObject.CompareTag("HabitacionAgua"))        //Cuando el personaje entra y está en la habitación de comida activa un bool que indica que está dentro de la habitación de comida
        {

            dentroAgua = true;
            if (!produciendo)
            {
                produciendo = true;
                StartCoroutine(generarRecursos());
                StartCoroutine(generarExperiencia());
            }

        }
        if (col.gameObject.CompareTag("HabitacionVeterinario"))
        {
            dentroVet = true;
            if(!produciendo)
            {
                produciendo = true;
                StartCoroutine(generarRecursos());
                StartCoroutine(generarExperiencia());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)             
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
    

    IEnumerator generarRecursos()
    {
        while (produciendo)
        {
            if (dentroComida)
            {

                yield return new WaitForSeconds(tiempo);
                if (ControladorDeRecursos.comida < ControladorDeRecursos.capacidadComida)
                {
                    ControladorDeRecursos.comida = ControladorDeRecursos.comida + cantidadRecursosBaseGenerados;
                }

            }
            else if (dentroElectricidad)
            {
                yield return new WaitForSeconds(tiempo);
                if (ControladorDeRecursos.electricidad < ControladorDeRecursos.capacidadElectricidad)
                {
                    ControladorDeRecursos.electricidad = ControladorDeRecursos.electricidad + cantidadRecursosBaseGenerados;
                }
            }
            else if (dentroAgua)
            {
                yield return new WaitForSeconds(tiempo);
                if (ControladorDeRecursos.agua < ControladorDeRecursos.capacidadAgua)
                {
                    ControladorDeRecursos.agua = ControladorDeRecursos.agua + cantidadRecursosBaseGenerados;
                }

            }
            else if (dentroVet)
            {
                yield return new WaitForSeconds(tiempoVendas);
                if(ControladorDeRecursos.vendas < ControladorDeRecursos.capacidadVendas)
                {
                    ControladorDeRecursos.vendas = ControladorDeRecursos.vendas + cantidadVendasGeneradas;
                }
            }
            else
            {
                produciendo = false;
            }
        }
    }
    IEnumerator generarExperiencia()
    {
        while (produciendo)
        {
            if (dentroComida)
            {

                yield return new WaitForSeconds(tiempo);
                if (ControladorDeRecursos.comida < ControladorDeRecursos.capacidadComida)
                {
                    ControladorDeRecursos.comida = ControladorDeRecursos.comida + cantidadRecursosBaseGenerados;
                }

            }
            else if (dentroElectricidad)
            {
                yield return new WaitForSeconds(tiempo);
                if (ControladorDeRecursos.electricidad < ControladorDeRecursos.capacidadElectricidad)
                {
                    ControladorDeRecursos.electricidad = ControladorDeRecursos.electricidad + cantidadRecursosBaseGenerados;
                }
            }
            else if (dentroAgua)
            {
                yield return new WaitForSeconds(tiempo);
                if (ControladorDeRecursos.agua < ControladorDeRecursos.capacidadAgua)
                {
                    ControladorDeRecursos.agua = ControladorDeRecursos.agua + cantidadRecursosBaseGenerados;
                }

            }
            else if (dentroVet)
            {
                yield return new WaitForSeconds(tiempoVendas);
                if (ControladorDeRecursos.vendas < ControladorDeRecursos.capacidadVendas)
                {
                    ControladorDeRecursos.vendas = ControladorDeRecursos.vendas + cantidadVendasGeneradas;
                }
            }
            else
            {
                produciendo = false;
            }
        }
    }
}
