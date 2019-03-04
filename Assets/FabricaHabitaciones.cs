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

    public int numeroHab = 1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CambiaNumeroHab(int num)
    {
        numeroHab = num;
    }

    public void FabricaHabitacion(Vector3 posicion)
    {
        if(numeroHab == 1)
        {
            if(ControladorDeRecursos.dinero -150 >= 0)
            { 
            Instantiate(HabElectricidad, posicion, transform.rotation);
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 150;
            }
        }

        if (numeroHab == 2)
        {
            if (ControladorDeRecursos.dinero - 170 >= 0)
            {
            Instantiate(HabDormitorios, posicion, transform.rotation);
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 170;
            }
        }

        if (numeroHab == 3)
        {
            if (ControladorDeRecursos.dinero - 125 >= 0)
            {
            Instantiate(HabComida, posicion, transform.rotation);
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 125;
            }
        }

        if (numeroHab == 4)
        {
            if (ControladorDeRecursos.dinero - 150 >= 0)
            {
            Instantiate(HabAgua, posicion, transform.rotation);
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 150;
            }
        }

        if (numeroHab == 5)

        {
            if (ControladorDeRecursos.dinero - 400 >= 0)
            {
            Instantiate(HabVeterinario, posicion, transform.rotation);
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero - 400;
            }
        }
    }
}
