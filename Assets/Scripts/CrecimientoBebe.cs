using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrecimientoBebe : MonoBehaviour
{
    public GameObject conejoGrandePrefab;
    public string apellidoElegido;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreceConejo", 60f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CreceConejo()
    {

        GameObject conejoCrecido=Instantiate(conejoGrandePrefab, transform.position, new Quaternion(0,0,0,0));
        conejoCrecido.GetComponent<EstadisticasPJ>().apellido = apellidoElegido; 
        Destroy(gameObject);
    }

}
