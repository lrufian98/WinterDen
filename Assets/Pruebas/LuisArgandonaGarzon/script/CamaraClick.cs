using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamaraClick : MonoBehaviour, UnityEngine.EventSystems.IPointerClickHandler
{
    public float duration = 20.0f;
    public float zoom = 2f;
    Camera camara;
   
    Vector3 posicionInicial;

    private float elapsed = 0.0f;
    private bool roomClicked = false;
    private bool transition = false;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = Camera.main.transform.position;
        camara = Camera.main;
        if(camara == null)
        {
            Debug.LogError("No se encuentra la camara");
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        if (transition) { 
            if (roomClicked)
            {
                elapsed += Time.deltaTime / duration;
                Zoom(zoom);
                Move(new Vector3(transform.position.x, transform.position.y, -10));
            }
            else
            {
                elapsed += Time.deltaTime / duration;
                Zoom(5);
                Move(posicionInicial);
            }
            if (elapsed > 1.0f)
            {
                transition = false;
            }
        }
    }
    
    private void Zoom(float zoomValue)
    {
        camara.orthographicSize = Mathf.Lerp(camara.orthographicSize, zoomValue, elapsed);
    }

    private void Move(Vector3 position)
    {
        camara.transform.position = Vector3.Lerp(camara.transform.position, position, elapsed);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
        if (eventData.clickCount == 2)
        {
            Debug.Log("Doble click " + transform.name);
            Debug.Log("Clicks " + eventData.clickCount);
            roomClicked = !roomClicked;
            elapsed = 0f;
            transition = true;
        }
    }
}
