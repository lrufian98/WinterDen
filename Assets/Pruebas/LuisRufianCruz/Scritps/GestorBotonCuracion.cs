using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GestorBotonCuracion : MonoBehaviour
{

    public Button botonVendas;
    public EstadisticasPJ scriptPJ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Curar()
    {
        Debug.Log("Boton Pulsado");
        if(scriptPJ != null)
        {
            scriptPJ.UsaVendas();

        }
        
    }
}
