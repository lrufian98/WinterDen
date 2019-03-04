using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EstadisticasPJ : MonoBehaviour
{

    public float tiempoGastoRecursos = 5f;

    public float vidaMaxConejo = 20;
    public float vidaActualConejo;
    public bool regenerando = false;
    public bool enCombate = false;

    GestorBotonCuracion scriptEnlaceUI;
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

    public float felicidad = 50;

    int nivelComida = 0;
    int debufoComida = 0;

    int nivelElectricidad = 0;
    int debufoElectricidad = 0;

    int nivelAgua = 0;
    int debufoAgua = 0;







    private void Awake()
    {
        scriptEnlaceUI=GameObject.Find("ControladorDeBotonVendas").GetComponent<GestorBotonCuracion>();

    }

    void Start()
    {
        StartCoroutine(GastoComida());
        StartCoroutine(GastoAgua());

        StartCoroutine(FelicidadRecursos());

        vidaActualConejo = vidaMaxConejo;

        aptitud = Random.Range(1, 4);
        carisma = Random.Range(1, 4);
        tecnica = Random.Range(1, 4);
        inteligencia = Random.Range(1, 4);
        vida = Random.Range(1, 4);
        energia = Random.Range(1, 4);
        suerte = Random.Range(1, 4);

        nombre = listaNombres[Random.Range(0, 29)];
        if (apellido == "")
        {
            apellido = listaApellidos[Random.Range(0, 29)];

        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!enCombate && vidaActualConejo<vidaMaxConejo)
        {
            if (!regenerando)
            {
                StartCoroutine(RegenerarVida());
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


        if (felicidad >100)
        {
            felicidad = 100;
        }


        if (ControladorDeRecursos.comida / ControladorDeRecursos.capacidadComida <=1 && ControladorDeRecursos.comida / ControladorDeRecursos.capacidadComida >0.5)
        {
            nivelComida = 0;
        }
        else if (ControladorDeRecursos.comida / ControladorDeRecursos.capacidadComida <= 0.5 && ControladorDeRecursos.comida / ControladorDeRecursos.capacidadComida > 0.25)
        {
            nivelComida = 1;
        }
        else if (ControladorDeRecursos.comida / ControladorDeRecursos.capacidadComida <= 0.25 && ControladorDeRecursos.comida / ControladorDeRecursos.capacidadComida > 0.1)
        {
            nivelComida = 2;
        }
        else if (ControladorDeRecursos.comida / ControladorDeRecursos.capacidadComida <= 0.1 && ControladorDeRecursos.comida / ControladorDeRecursos.capacidadComida > 0.05)
        {
            nivelComida = 3;
        }
        else if (ControladorDeRecursos.comida / ControladorDeRecursos.capacidadComida <= 0.05 && ControladorDeRecursos.comida / ControladorDeRecursos.capacidadComida >= 0)
        {
            nivelComida = 4;
        }

        if (ControladorDeRecursos.electricidad / ControladorDeRecursos.capacidadElectricidad <= 1 && ControladorDeRecursos.electricidad / ControladorDeRecursos.capacidadElectricidad > 0.5)
        {
            nivelElectricidad = 0;
        }
        else if (ControladorDeRecursos.electricidad / ControladorDeRecursos.capacidadElectricidad <= 0.5 && ControladorDeRecursos.electricidad / ControladorDeRecursos.capacidadElectricidad > 0.25)
        {
            nivelElectricidad = 1;
        }
        else if (ControladorDeRecursos.electricidad / ControladorDeRecursos.capacidadElectricidad <= 0.25 && ControladorDeRecursos.electricidad / ControladorDeRecursos.capacidadElectricidad > 0.1)
        {
            nivelElectricidad = 2;
        }
        else if (ControladorDeRecursos.electricidad / ControladorDeRecursos.capacidadElectricidad <= 0.1 && ControladorDeRecursos.electricidad / ControladorDeRecursos.capacidadElectricidad > 0.05)
        {
            nivelElectricidad = 3;
        }
        else if (ControladorDeRecursos.electricidad / ControladorDeRecursos.capacidadElectricidad <= 0.05 && ControladorDeRecursos.electricidad / ControladorDeRecursos.capacidadElectricidad >= 0)
        {
            nivelElectricidad = 4;
        }



        if (ControladorDeRecursos.agua / ControladorDeRecursos.capacidadAgua <= 1 && ControladorDeRecursos.agua / ControladorDeRecursos.capacidadAgua > 0.5)
        {
            nivelAgua = 0;
        }
        else if (ControladorDeRecursos.agua / ControladorDeRecursos.capacidadAgua <= 0.5 && ControladorDeRecursos.agua / ControladorDeRecursos.capacidadAgua > 0.25)
        {
            nivelAgua = 1;
        }
        else if (ControladorDeRecursos.agua / ControladorDeRecursos.capacidadAgua <= 0.25 && ControladorDeRecursos.agua / ControladorDeRecursos.capacidadAgua > 0.1)
        {
            nivelAgua = 2;
        }
        else if (ControladorDeRecursos.agua / ControladorDeRecursos.capacidadAgua <= 0.1 && ControladorDeRecursos.agua / ControladorDeRecursos.capacidadAgua > 0.05)
        {
            nivelAgua = 3;
        }
        else if (ControladorDeRecursos.agua / ControladorDeRecursos.capacidadAgua <= 0.05 && ControladorDeRecursos.agua / ControladorDeRecursos.capacidadAgua >= 0)
        {
            nivelAgua = 4;
        }


    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("HabitacionDormitorio"))
        {
            felicidad += +5;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("HabitacionDormitorio"))
        {
            felicidad += -5;
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

    IEnumerator FelicidadRecursos()
    {
        while (true)
        {
            switch (nivelComida)
            {
                case 0 :
                    
                    Debug.Log("No te rayes la comida bien");
                    if (debufoComida == 1)
                    {
                        felicidad += 4;
                    }
                    debufoComida = 0;
                    break;

                case 1:
                    if (debufoComida != 1)
                    {
                        if (debufoComida == 2)
                        {
                            felicidad += 6;
                        }
                        felicidad += -4;
                        debufoComida = 1;
                    }
                    
                    break;

                case 2:
                    if (debufoComida != 2)
                    {
                        if(debufoComida == 3)
                        {
                            felicidad += 8;
                        }
                        felicidad += -6;
                        debufoComida = 2;
                    }
                    
                    break;

                case 3:
                    if (debufoComida!=3)
                    {
                        if (debufoComida == 4)
                        {
                            felicidad += 10;
                        }
                        felicidad += -8;
                        debufoComida = 3;
                    }
                    break;

                case 4:
                    if (debufoComida!=4)
                    {
                        felicidad += -10;
                        debufoComida = 4;
                    }

                    break;

            }

            switch (nivelElectricidad)
            {
                case 0:

                    Debug.Log("No te rayes la electricidad bien");
                    if (debufoElectricidad == 1)
                    {
                        felicidad += 4;
                    }
                    debufoElectricidad = 0;
                    break;

                case 1:
                    if (debufoElectricidad != 1)
                    {
                        if (debufoElectricidad == 2)
                        {
                            felicidad += 6;
                        }
                        felicidad += -4;
                        debufoElectricidad = 1;
                    }

                    break;

                case 2:
                    if (debufoElectricidad != 2)
                    {
                        if (debufoElectricidad == 3)
                        {
                            felicidad += 8;
                        }
                        felicidad += -6;
                        debufoElectricidad = 2;
                    }
                    break;

                case 3:
                    if (debufoElectricidad != 3)
                    {
                        if (debufoElectricidad == 4)
                        {
                            felicidad += 10;
                        }
                        felicidad += -8;
                        debufoElectricidad = 3;
                    }
                    break;

                case 4:
                    if (debufoElectricidad != 4)
                    {
                        felicidad += -10;
                        debufoElectricidad = 4;
                    }
                    break;

            }
            switch (nivelAgua)
            {
                case 0:

                    Debug.Log("No te rayes el agua bien");
                    if (debufoAgua == 1)
                    {
                        felicidad += 4;
                    }
                    debufoAgua = 0;
                    break;

                case 1:
                    if (debufoAgua != 1)
                    {
                        if (debufoAgua == 2)
                        {
                            felicidad += 6;
                        }
                        felicidad += -4;
                        debufoAgua = 1;
                    }

                    break;

                case 2:
                    if (debufoAgua != 2)
                    {
                        if (debufoAgua == 3)
                        {
                            felicidad += 8;
                        }
                        felicidad += -6;
                        debufoAgua = 2;
                    }

                    break;

                case 3:
                    if (debufoAgua != 3)
                    {
                        if (debufoAgua == 4)
                        {
                            felicidad += 10;
                        }
                        felicidad += -8;
                        debufoAgua = 3;
                    }
                    break;

                case 4:
                    if (debufoAgua != 4)
                    {
                        felicidad += -10;
                        debufoAgua = 4;
                    }

                    break;

            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void UsaVendas()
    {
        if (ControladorDeRecursos.vendas>0)
        {
            Debug.Log("Usando Vendas");
            if (vidaActualConejo < vidaMaxConejo)
            {
                vidaActualConejo = vidaActualConejo + (vidaMaxConejo / 2);
                felicidad += 10;
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

    IEnumerator GastoAgua()
    {
        while (true)
        {
            Debug.Log("A beber");
            if (ControladorDeRecursos.agua > 0)
            {
                ControladorDeRecursos.agua--;
                Debug.Log("Bajando Agua");
            }

            yield return new WaitForSeconds(tiempoGastoRecursos);
        }



    }
    IEnumerator GastoComida()
    {
        while (true)
        {

            Debug.Log("A comer");
            if (ControladorDeRecursos.comida > 0)
            {
                ControladorDeRecursos.comida--;
                Debug.Log("Bajando Comida");
            }
            yield return new WaitForSeconds(tiempoGastoRecursos);
        }


    }

    public void QuitaVida(int cantidad)
    {
        vida -= cantidad;
        GetComponent<ArrastreHabitacionLRC>().RecibirDanoConejo();

        if (vida <=0)
        {
           GetComponent<ArrastreHabitacionLRC>().MorirConejo();
        }
    } 

}
