using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbrirInfoConejo : MonoBehaviour
{
    
    public Animator animInfoConejo;
    bool activaInfoConejo = false;

    public Image barraA;

    public Image barraC;

    public Image barraT;

    public Image barraI;

    public Image barraV;

    public Image barraE;

    public Image barraS;

    public Text nivel;

    public EstadisticasPJ statsPJ;

    public Image barraVida;

    public Text nombreApellido;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        AbreMenuInfo();
        PasaInfo();
    }


    public void AbreMenuInfo()
    {
        activaInfoConejo = !activaInfoConejo;
        animInfoConejo.SetBool("MenuActivo", activaInfoConejo);
    }

    public void PasaInfo()
    {
        nombreApellido.text = statsPJ.nombre + " " + statsPJ.apellido;
        barraA.fillAmount = statsPJ.aptitud / 10;
        barraC.fillAmount = statsPJ.carisma / 10;
        barraT.fillAmount = statsPJ.tecnica / 10;
        barraI.fillAmount = statsPJ.inteligencia / 10;
        barraV.fillAmount = statsPJ.vida / 10;
        barraE.fillAmount = statsPJ.energia / 10;
        barraS.fillAmount = statsPJ.suerte / 10;

        barraVida.fillAmount = statsPJ.vidaActualConejo / statsPJ.vidaMaxConejo;

        nivel.text = "NV " + statsPJ.nivelTotal;

       
    }

}
