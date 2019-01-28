using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeRecursos : MonoBehaviour
{
    public static int electricidad;
    public static int capacidadElectricidad = 100;

    public Text electricidadUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        electricidadUI.text = electricidad.ToString();
    }
}
