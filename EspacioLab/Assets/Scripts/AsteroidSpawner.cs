using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float tumble;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                var newAsteroid = Instantiate(hazard, spawnPosition, spawnRotation);

                newAsteroid.GetComponent<Rigidbody2D>().angularVelocity = UnityEngine.Random.Range(-tumble, tumble);
                //newAsteroid.GetComponent<Rigidbody>().angularVelocity = new Vector3(UnityEngine.Random.Range(-tumble, tumble), UnityEngine.Random.Range(-tumble, tumble), UnityEngine.Random.Range(-tumble, tumble)) ;
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

}
