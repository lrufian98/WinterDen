using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClick : MonoBehaviour
{
    Vector3 posicionInicial;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(startMarker.positionInicial, endMarker.position.vector3, fracJourney);
        //transform.position = Vector3.Lerp(posicionInicial.position, Vector3.position, fracJourney);
    }

    void OnMouseDown()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        Debug.Log("Click");
    }
}
