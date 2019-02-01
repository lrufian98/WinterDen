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

    // Start is called before the first frame update
    void Start()
    {
        vidaActualConejo = vidaMaxConejo;
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

    public void usaVendas()
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
