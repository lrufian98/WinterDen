using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraClick : MonoBehaviour, UnityEngine.EventSystems.IPointerClickHandler
{
    public float duration = 20.0f;
    public float zoom = 2f;
    
    Vector3 posicionInicial;

    private float elapsed = 0.0f;
    private bool roomClicked = false;


    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (roomClicked)
        {
            elapsed += Time.deltaTime / duration;
            Zoom(zoom);
            Move(new Vector3(transform.position.x, transform.position.y, -10));
        }
        else
        {
            Zoom(5);
            Move(posicionInicial);
        }
    }
    
    private void Zoom(float zoomValue)
    {
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoomValue, elapsed);
    }

    private void Move(Vector3 position)
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, position, elapsed);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            roomClicked = !roomClicked;
        }
    }
}
