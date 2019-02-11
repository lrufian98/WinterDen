using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class abrirInfoConejo : MonoBehaviour, IPointerDownHandler
{

    public GameObject CanvasInfoConejo;
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
            CanvasInfoConejo.SetActive(true);
        }
        else
        {
            CanvasInfoConejo.SetActive(false);
        }
    }
}
