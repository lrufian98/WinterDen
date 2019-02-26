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
    }

    void OnMouseDown()
    {
          
        Debug.Log("Fabricando!!!");
        scriptFabrica.FabricaHabitacion(transform.position);
        Destroy(gameObject);
    }
}
