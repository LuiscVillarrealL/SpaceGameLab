using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConf> waveConfs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // var currentWave = waveConfs[startingWave];
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);

      //  StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfs.Count; waveIndex++)
        {
            var currentWave = waveConfs[waveIndex];
            yield return StartCoroutine(SpawnEnemiesInWave(currentWave));
        }
    }

   private IEnumerator SpawnEnemiesInWave(WaveConf waveConf)
    {

        for(int enemyCount = 0; enemyCount < waveConf.GetNumberOfEnemies(); enemyCount++)
        {
           var newEnemy = Instantiate(waveConf.GetEnemyPrefab(), waveConf.GetWaypoints()[0].transform.position, Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConf);

            yield return new WaitForSeconds(waveConf.GetSpawnRate());
        }
       

        
    }
}
