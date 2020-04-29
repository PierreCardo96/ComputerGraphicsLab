using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectHit : MonoBehaviour
{
    [SerializeField]
    string opponent;

    [SerializeField]
    float chasingForAttackingTime = 10f;

    private EnemyMovement enemyMovement;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == opponent)
        {
            enemyMovement.SetIsAttacked(true);
            Invoke("SetIsAttackedToFalse", chasingForAttackingTime);
        }
    }

    private void SetIsAttackedToFalse()
    {
        enemyMovement.SetIsAttacked(false);
    }
}
