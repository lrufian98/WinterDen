using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaHabitaciones : MonoBehaviour
{
    public GameObject HabElectricidad; //1
    public GameObject HabDormitorios;   //2
    public GameObject HabComida;        //3
    public GameObject HabAgua;         //4
    public GameObject HabVeterinario;   //5
    public GameObject HabAscensor;      //6
    public bool millonario = true;
    int numeroHab = 0;

    bool activaConsHabitaciones = false;
    GameObject compra;
    // Start is called before the first frame update
    void Start()
    {
        if (millonario)
        {
            ControladorDeRecursos.dinero = 1000;
        }

        compra = GameObject.Find("interfazCompra");
    }

    public void AbreCierraMenuInfo()
    {
        activaConsHabitaciones = !activaConsHabitaciones;
        compra.SetActive(activaConsHabitaciones);

    }


    public void CambiaNumeroHab(int num)
    {
        numeroHab = num;
        Debug.Log("Habitacion Seleccionada:" + num);
    }

    public bool FabricaHabitacion(Vector3 posicion)
    {
        bool fabricada = false;
       


        if (numeroHab == 0)
        {
            Debug.LogWarning("No se ha seleccionado habitacion");

        }
        if (numeroHab == 1)
        {
            Debug.Log("Frabricando Habitacion:" + numeroHab);
            Debug.Log("Posicion:" + posicion.x + ","+posicion.y);
            if (ControladorDeRecursos.dinero  >= 150)
            { 
            Instantiate(HabElectricidad, posicion, transform.rotation);
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 150;
                fabricada = true;
            }
            else
            {
                Debug.Log("No hay dinero");
            }
        }

        if (numeroHab == 2)
        {
            if (ControladorDeRecursos.dinero >= 170)
            {
            Instantiate(HabDormitorios, posicion, transform.rotation);
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 170;
                fabricada = true;
            }
            else
            {
                Debug.Log("No hay dinero");
            }
        }

        if (numeroHab == 3)
        {
            if (ControladorDeRecursos.dinero  >= 125)
            {
            Instantiate(HabComida, posicion, transform.rotation);
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 125;
                fabricada = true;
            }
            else
            {
                Debug.Log("No hay dinero");
            }
        }

        if (numeroHab == 4)
        {
            if (ControladorDeRecursos.dinero >= 150)
            {
            Instantiate(HabAgua, posicion, transform.rotation);
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 150;
                fabricada = true;
            }
            else
            {
                Debug.Log("No hay dinero");
            }
        }

        if (numeroHab == 5)

        {
            if (ControladorDeRecursos.dinero >= 400)
            {
            Instantiate(HabVeterinario, posicion, transform.rotation);
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 400;
                fabricada = true;
            }
            else
            {
                Debug.Log("No hay dinero");
            }
        }

        if (numeroHab == 6)
        {
            if (ControladorDeRecursos.dinero >= 300)
            {
                Instantiate(HabAscensor, posicion, transform.rotation);
                ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 300;
                fabricada = true;
            }
            else {
                Debug.Log("No hay dinero");
            }
            
           
        }

        numeroHab = 0;
        return fabricada;
    }
}
