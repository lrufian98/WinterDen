using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
   

    public void CargaJuego()
    {
        SceneManager.LoadScene("PantallaJuego");
    }

    public void CargaAjustes()
    {
        SceneManager.LoadScene("PantallaAjustes");
    }

    public void CargaMadrigueras()
    {
        SceneManager.LoadScene("PantallaMadrigueras");
    }
    public void CargaPantallaInicio()
    {
        SceneManager.LoadScene("PantallaInicial");
    }


}
