using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorZorros : MonoBehaviour
{
    //Spawn this object
    public GameObject zorro1, zorro2, zorro3;

    public float maxTime = 5;
    public float minTime = 2;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }

    }


    //Spawns the object and resets the time
    void SpawnObject()
    {
        time = minTime;
        Instantiate(zorro1, transform.position, zorro1.transform.rotation);
        Instantiate(zorro2, transform.position, zorro2.transform.rotation);
        Instantiate(zorro3, transform.position, zorro3.transform.rotation);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}

