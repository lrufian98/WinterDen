using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoZorro : MonoBehaviour
{
    public float velocidad = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime, 0, 0);
    }
}
