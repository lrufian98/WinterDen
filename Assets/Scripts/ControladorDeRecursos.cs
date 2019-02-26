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

    public static float felicidadTotal = 0;

    public Image barraElectricidad;
    public Image barraComida;
    public Image barraAgua;



    public Text felicidadUI;
    public Image caraFeliz;

    public Text vendasUI;
    public Text dineroUI;


    public Text numeroConejos;


    private void Awake()
    {
        numeroConejos = GameObject.Find("numeroConejos").GetComponent<Text>();
        felicidadUI = GameObject.Find("TextoFelicidad").GetComponent<Text>();
        caraFeliz = GameObject.Find("ImagenFelicidad").GetComponent<Image>();
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
        GameObject[] conejos = GameObject.FindGameObjectsWithTag("Conejos");

        felicidadTotal = 0;
        foreach(GameObject conejo in conejos)
        {
            felicidadTotal += conejo.GetComponent<EstadisticasPJ>().felicidad / conejos.Length;
        }
        felicidadUI.text = Mathf.RoundToInt(felicidadTotal).ToString() + "%";
        

        GameObject.FindGameObjectsWithTag("Conejos");
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
