using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbrirInfoConejo : MonoBehaviour
{
    
    Animator animInfoConejo;
    bool activaInfoConejo = false;
    public Animator vidaEncima;

    public Image BVE;

    Image barraA;

    Image barraC;

    Image barraT;

    Image barraI;

    Image barraV;

    Image barraE;

    Image barraS;

    Text nivel;

    public EstadisticasPJ statsPJ;

    Text nombreConejo;

    private void Awake()
    {
        barraA = GameObject.Find("barraStatsFill A").GetComponent<Image>();
        barraC = GameObject.Find("barraStatsFill C").GetComponent<Image>();
        barraT = GameObject.Find("barraStatsFill T").GetComponent<Image>();
        barraI = GameObject.Find("barraStatsFill I").GetComponent<Image>();
        barraV = GameObject.Find("barraStatsFill V").GetComponent<Image>();
        barraE = GameObject.Find("barraStatsFill E").GetComponent<Image>();
        barraS = GameObject.Find("barraStatsFill S").GetComponent<Image>();

        nivel = GameObject.Find("nivel").GetComponent<Text>();
        nombreConejo = GameObject.Find("nombreConejo").GetComponent<Text>();


        animInfoConejo = GameObject.Find("fondoMenuConejo").GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BVE.fillAmount = statsPJ.vidaActualConejo / statsPJ.vidaMaxConejo;
    }

    public void OnMouseDown()
    {
        AbreMenuInfo();
        BarraVidaSuperior();
        PasaInfo();
        


    }


    public void AbreMenuInfo()
    {
        activaInfoConejo = !activaInfoConejo;
        animInfoConejo.SetBool("MenuActivo", activaInfoConejo);
    }

    public void PasaInfo()
    {
        barraA.fillAmount = statsPJ.aptitud / 10;
        barraC.fillAmount = statsPJ.carisma / 10;
        barraT.fillAmount = statsPJ.tecnica / 10;
        barraI.fillAmount = statsPJ.inteligencia / 10;
        barraV.fillAmount = statsPJ.vida / 10;
        barraE.fillAmount = statsPJ.energia / 10;
        barraS.fillAmount = statsPJ.suerte / 10;
        BVE.fillAmount = statsPJ.vidaActualConejo / statsPJ.vidaMaxConejo;
        nivel.text = "NV " + statsPJ.nivelTotal;
        nombreConejo.text = statsPJ.nombre + " " + statsPJ.apellido;
    }
    public void BarraVidaSuperior()
    {
        if (vidaEncima.GetBool("SalirBarraVida") == true)
        {
            vidaEncima.SetBool("SalirBarraVida", false);
        }
        else
        {
            vidaEncima.SetBool("SalirBarraVida", true);
        }
    }

}
