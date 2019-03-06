using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoZorro : MonoBehaviour
{
    public float velocidad = 5f;
    private bool derecha = true;

    private int direccion;

    // Start is called before the first frame update
    void Start()
    {
        direccion = 1;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(velocidad * Time.deltaTime * direccion, 0, 0);
    }

    public void flip()
    {
        derecha = !derecha;
        if (derecha)
        {
            direccion = 1;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            direccion = -1;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
