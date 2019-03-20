using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorIterfaz : MonoBehaviour
{
    //Script que abre y cierra los menús de la interfaz


    public Animator animMenuAjustes;
    public Animator animMenuMejora;
    public Animator animMenuExpediciones;
    public Animator animConejosEnSala;

    public abrirInfoConejo menuConejo;
    public GameObject canvasCompra;

    bool activaMenuAjustes = false;
   
    bool activaMenuMejora = false;
    bool activaConejosEnSala = false;

    // Start is called before the first frame update

   

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ApareceConejosEnSala()
    {
        activaConejosEnSala = !activaConejosEnSala;
        animConejosEnSala.SetBool("MenuActivo", activaConejosEnSala);
    }

    public void MenuConejos()
    {
        abrirInfoConejo.AbreMenuInfo();
    }
   

    public void ApareceMenuAjustes()
    {
        activaMenuAjustes = !activaMenuAjustes;
        animMenuAjustes.SetBool("MenuActivo", activaMenuAjustes);

        FindObjectOfType<AudioManager>().Play("Click");
    }
    public void ApareceMenuMejora()
    {
        activaMenuMejora = !activaMenuMejora;
        animMenuMejora.SetBool("MenuActivo", activaMenuMejora);

        FindObjectOfType<AudioManager>().Play("Click");
    }
    public void DesapareceMenuExpediciones()
    {
        animMenuExpediciones.SetBool("MenuActivo", false);

        FindObjectOfType<AudioManager>().Play("Click");
    }
}
