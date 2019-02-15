using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EstadisticasPJ : MonoBehaviour
{

    public int vidaMaxConejo = 20;
    public int vidaActualConejo;
    public bool regenerando = false;
    public bool enCombate = false;

    public GestorBotonCuracion scriptEnlaceUI;
    public EstadisticasPJ miScript;

    public float aptitud;
    public float expAp;
    

    public float carisma;
    public float expCar;


    public float tecnica;
    public float expTec;


    public float inteligencia;
    public float expInt;


    public float vida;
    public float expVid;


    public float energia;
    public float expEn;


    public float suerte;
    public float expSu;



    int nivelMaximo = 10;
    public int expBase = 500;

    public float nivelTotal;

    public List<string> listaNombres;
    public List<string> listaApellidos;
    public string nombre;
    public string apellido;


    // Start is called before the first frame update
    void Start()
    {
        vidaActualConejo = vidaMaxConejo;

        aptitud = Random.Range(1, 4);
        carisma = Random.Range(1, 4);
        tecnica = Random.Range(1, 4);
        inteligencia = Random.Range(1, 4);
        vida = Random.Range(1, 4);
        energia = Random.Range(1, 4);
        suerte = Random.Range(1, 4);

        nombre = listaNombres[Random.Range(0, 29)];
        apellido = listaApellidos[Random.Range(0, 29)];


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!enCombate && vidaActualConejo<vidaMaxConejo)
        {
            if (!regenerando)
            {
                //StartCoroutine(RegenerarVida());
            }
            
        }

        if (expAp > expBase + expBase*aptitud)
        {
            if (aptitud < nivelMaximo) aptitud++;
            expAp = 0;
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero + 5 + aptitud;
        }
        if (expEn > expBase + expBase*energia)
        {
            if (energia < nivelMaximo)energia++;
            expEn = 0;
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero + 5 + energia;
        }
        if (expTec > expBase + expBase*tecnica)
        {
            if(tecnica < nivelMaximo)tecnica++;
            expTec = 0;
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero + 5 + tecnica;
        }
        if (expInt > expBase + expBase*inteligencia)
        {
            if(inteligencia < nivelMaximo) inteligencia++;
            expInt = 0;
            ControladorDeRecursos.dinero = ControladorDeRecursos.dinero + 5 + inteligencia;
        }

        nivelTotal = aptitud + carisma + tecnica + inteligencia + vida + energia + suerte;

    }

  
   IEnumerator RegenerarVida()
    {
        
        while (!enCombate && vidaActualConejo < vidaMaxConejo)
        {
            
            regenerando = true;
            vidaActualConejo++;
            yield return new WaitForSeconds(1f);
            
        }
        regenerando = false;
    }

    public void UsaVendas()
    {
        if (ControladorDeRecursos.vendas>0)
        {
            Debug.Log("Usando Vendas");
            if (vidaActualConejo < vidaMaxConejo)
            {
                vidaActualConejo = vidaActualConejo + (vidaMaxConejo / 2);
                if (vidaActualConejo > vidaMaxConejo)
                {
                    vidaActualConejo = vidaMaxConejo;
                }
                ControladorDeRecursos.vendas--;
            }
            
        }

    }
    public void OnMouseDown()
    {
        scriptEnlaceUI.scriptPJ = miScript;
    }




}
