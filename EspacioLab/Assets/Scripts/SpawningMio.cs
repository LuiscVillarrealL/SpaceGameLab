using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningMio : MonoBehaviour
{

    [SerializeField] GameObject spawnObject;
    [SerializeField] List<Transform> waypoints;

    [SerializeField] float maxTime = 2;
    [SerializeField] float minTime = 0;

    private float time;

    private float spawnTime;

    // Start is called before the first frame update
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
        time = 0;

        Instantiate(spawnObject, waypoints[Random.Range(0, 3)].transform.position, spawnObject.transform.rotation);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }



}
