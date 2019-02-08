using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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


}
