using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyBehaviour
{
    Static,
    Patroling
}

public class EnemyMovementController : MonoBehaviour
{
    EnemyController enemyController;
    [SerializeField] List<GameObject> waypoints = new List<GameObject>();
    [SerializeField] List<Vector3> waypointsTransform = new List<Vector3>();
    [SerializeField] EnemyBehaviour enemyBehaviour = EnemyBehaviour.Static;

    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private int currentPatrolIndex = 0;

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
        if(waypoints == null)
        {
            enemyBehaviour = EnemyBehaviour.Static;
        }
        else
        {
            enemyBehaviour = EnemyBehaviour.Patroling;
            foreach (GameObject waypoint in waypoints)
            {
                waypointsTransform.Add(waypoint.transform.position);
            }
        }
    }

    private void Update()
    {
        if(enemyBehaviour == EnemyBehaviour.Patroling)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypointsTransform[currentPatrolIndex], moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypointsTransform[currentPatrolIndex]) > 0.1f)
        {
            transform.LookAt(waypointsTransform[currentPatrolIndex]);
        }

        // If the enemy reaches the current patrol point, move to the next one
        if (Vector3.Distance(transform.position, waypointsTransform[currentPatrolIndex]) < 0.1f)
        {
            if(currentPatrolIndex < waypointsTransform.Count)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % waypointsTransform.Count;
            }
            else if ( currentPatrolIndex == waypointsTransform.Count)
            {
                currentPatrolIndex = 0;
            }

        }
    }

}
