using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeRecursos : MonoBehaviour
{
    public static float electricidad;
    public static float capacidadElectricidad = 100f;

    public static float comida;
    public static float capacidadComida = 100;

    public static float agua;
    public static float capacidadAgua = 100;

    public static float vendas;
    public static float capacidadVendas = 10;

    public static float dinero;

    public Image barraElectricidad;
    public Image barraComida;
    public Image barraAgua;

    

    public Text vendasUI;
    public Text dineroUI;


    public Text numeroConejos;


    private void Awake()
    {
        numeroConejos = GameObject.Find("numeroConejos").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(vendasUI != null)
        {
            vendasUI.text = vendas.ToString();
        }
        else
        {
            Debug.LogError("Hace falta linkar vendas");
        }
        if (dineroUI)
        {
            dineroUI.text = dinero.ToString();
        }
       
        barraElectricidad.fillAmount =  electricidad/capacidadElectricidad;
        barraComida.fillAmount = comida / capacidadComida;
        barraAgua.fillAmount = agua / capacidadAgua;
        

        numeroConejos.text =GameObject.FindGameObjectsWithTag("Conejos").Length.ToString();
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
