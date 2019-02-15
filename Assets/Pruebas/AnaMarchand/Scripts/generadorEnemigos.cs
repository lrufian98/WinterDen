using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorEnemigos : MonoBehaviour
{
    public GameObject enemigo;
    float randX;
    Vector2 dondeGenerarEnemigos;
    public float frecuenciaGeneracion;
    float siguienteEnemigo = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > siguienteEnemigo)
        {
            siguienteEnemigo = Time.time + frecuenciaGeneracion;
            //randX = Random.Range(-10f, 10f);
            dondeGenerarEnemigos = new Vector2(transform.position.x, transform.position.y);
            Instantiate(enemigo, dondeGenerarEnemigos, Quaternion.identity);
        }
    }
}
