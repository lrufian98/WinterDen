using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public void CargaJuego()
    {
        SceneManager.LoadScene("PantallaJuegoFinal");

        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void CargaAjustes()
    {
        SceneManager.LoadScene("PantallaAjustes");

        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void CargaMadrigueras()
    {
        SceneManager.LoadScene("PantallaMadrigueras");

        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void CargaPantallaInicio()
    {
        SceneManager.LoadScene("PantallaInicial");

        FindObjectOfType<AudioManager>().Play("Click");
    }
}
