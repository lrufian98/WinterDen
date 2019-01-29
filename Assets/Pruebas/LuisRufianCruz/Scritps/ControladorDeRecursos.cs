using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeRecursos : MonoBehaviour
{
    public static int electricidad;
    public static int capacidadElectricidad = 100;

    public static int comida;
    public static int capacidadComida = 100;

    public static int agua;
    public static int capacidadAgua = 100;


    public Text electricidadUI;
    public Text comidaUI;
    public Text aguaUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        electricidadUI.text = electricidad.ToString();
        comidaUI.text = comida.ToString();
        aguaUI.text = agua.ToString();
    }
}
