using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class menuConstruir : MonoBehaviour, IPointerDownHandler
{

    public GameObject menuConstruccion;
    int counter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        counter++;
        if (counter % 2 == 1)
        {
            menuConstruccion.SetActive(true);
        }
        else
        {
            menuConstruccion.SetActive(false);
        }
    }
}
