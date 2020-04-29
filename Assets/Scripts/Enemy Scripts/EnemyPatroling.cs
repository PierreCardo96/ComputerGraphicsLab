using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroling : MonoBehaviour
{

    [SerializeField]
    float accuracyWaypoint = 1f;
    [SerializeField]
    int numberOfWaypoints = 10;
    [SerializeField]
    int patrolingRadius = 5;

    [SerializeField]
    float terrainOffset = 10f;

    private List<Vector3> waypoints = new List<Vector3>();
    private int currentWaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        InitializePatrolingRoute();
    }

    private void InitializePatrolingRoute()
    {
        int i = numberOfWaypoints;
        while (i > 0)
        {
            float randX = UnityEngine.Random.Range(-patrolingRadius, patrolingRadius);
            float randZ = UnityEngine.Random.Range(-patrolingRadius, patrolingRadius);
            float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));
            Vector3 waypoint = new Vector3(randX, yVal - terrainOffset, randZ);
            waypoints.Add(waypoint + transform.position);
            i--;
        }
    }

    public void Patrole(float speed, float rotationSpeed)
    {
        if(waypoints.Count == 0)
        {
            return;
        }

        if (Vector3.Distance(waypoints[currentWaypoint], transform.position) < accuracyWaypoint)
        {
            currentWaypoint = UnityEngine.Random.Range(0, waypoints.Count);
        }
        Vector3 direction = waypoints[currentWaypoint] - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
