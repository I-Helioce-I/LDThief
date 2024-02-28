using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyMovementController enemyMovementController;

    private void Start()
    {
        enemyMovementController = GetComponent<EnemyMovementController>();
    }
}
