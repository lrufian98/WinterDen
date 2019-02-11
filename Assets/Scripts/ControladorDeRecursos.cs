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

    public static int vendas;
    public static int capacidadVendas = 10;

    public static int dinero;
    


    public Text electricidadUI;
    public Text comidaUI;
    public Text aguaUI;
    public Text vendasUI;
    public Text dineroUI;


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
        vendasUI.text = vendas.ToString();
        dineroUI.text = dinero.ToString();
    }

    public void DineroExpedicion()
    {

        dinero = dinero + Random.Range(250,1000);

    }
    public void DineroSaqueo()
    {
        dinero = dinero + Random.Range(150,200);
    }


}
