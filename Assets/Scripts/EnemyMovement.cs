using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    float speed = 1.5f;
    [SerializeField]
    float rotationSpeed = 1f;

    [SerializeField]
    float viewAngle = 30f;
    [SerializeField]
    float attackingDistance = 1.5f;
    [SerializeField]
    float chaseDistance = 10f;


    private EnemyPatroling enemyPatroling;
    private EnemyAnimator enemyAnimator;
    private EnemyState enemyState = EnemyState.Patroling;

    // Start is called before the first frame update
    void Start()
    {
        enemyPatroling = GetComponent<EnemyPatroling>();
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessEnemyMovement();
    }
    private void ProcessEnemyMovement()
    {
        
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        direction.y = 0f;//TODO: Check if it is neccessary
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        
        //player is alive, is in the radius and (is in the viewAngle or the enemy already attacking or chasing)
        if (player.GetHealth() > 0 && playerDistance <= chaseDistance && 
            (angle<=viewAngle || enemyState != EnemyState.Patroling ))
        {
            PlayerTracking(direction);
        }
        else
        {
            ProcessPatroling();
        }
    }
    private void ProcessChasing()
    {
        enemyState = EnemyState.Chasing;
        transform.Translate(0, 0, speed * Time.deltaTime);
        enemyAnimator.UpdateEnemyState(EnemyState.Chasing);
    }
    private void ProcessAttacking()
    {
        enemyState = EnemyState.Attacking;
        enemyAnimator.UpdateEnemyState(EnemyState.Attacking);
    }
    private void ProcessPatroling()
    {
        enemyState = EnemyState.Patroling;
        enemyAnimator.UpdateEnemyState(EnemyState.Patroling);
        enemyPatroling.Patrole(speed, rotationSpeed);
    }
    private void PlayerTracking(Vector3 direction)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                    Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        if (direction.magnitude > attackingDistance)
        {
            ProcessChasing();
        }
        else
        {
            ProcessAttacking();
        }
    }
}
