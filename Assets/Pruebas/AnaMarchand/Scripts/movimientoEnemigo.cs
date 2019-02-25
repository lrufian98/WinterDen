using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimientoEnemigo : MonoBehaviour
{
    public float visionRadius = 20;
    public float velocidad = 1;

    GameObject player;

    Vector3 posicionInicial;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Conejos");

        posicionInicial = transform.position;
    }

    void Update()
    {
        Vector3 target = posicionInicial;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius) target = player.transform.position;

        float fixedSpeed = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        if (posicionInicial.x < player.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}