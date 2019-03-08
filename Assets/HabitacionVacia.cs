using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitacionVacia : MonoBehaviour
{
    FabricaHabitaciones scriptFabrica;
    // Start is called before the first frame update
    void Start()
    {
        scriptFabrica = transform.parent.gameObject.GetComponent<FabricaHabitaciones>();
        if(scriptFabrica == null)
        {
            Debug.LogError("No se encuentra el objeto FabricaHabitaciones");
        }
    }

    void OnMouseDown()
    {
          
        Debug.Log("Fabricando!!!");
        if (scriptFabrica.FabricaHabitacion(transform.position))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No se ha podido fabricar");
        }
        
    }
}
