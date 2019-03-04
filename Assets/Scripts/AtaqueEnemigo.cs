using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{

    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.right), 1, layerMask);






        if (hit)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1, Color.yellow);
            Debug.Log("Did Hit " + hit.transform.name);
           

            hit.collider.gameObject.GetComponent<EstadisticasPJ>().QuitaVida(1);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
