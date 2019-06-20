using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] WaveConf waveConf;
    List<Transform> waypoints;
    
    int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConf.GetWaypoints();
        transform.position = waypoints[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConf waveConf)
    {
        this.waveConf = waveConf;
    }

    private void Move()
    {
        if (wayPointIndex <= waypoints.Count - 1)
        {


            var targetPosition = waypoints[wayPointIndex].transform.position;
            var movThisFrame = waveConf.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movThisFrame);

            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
