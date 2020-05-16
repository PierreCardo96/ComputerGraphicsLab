using Assets.Scripts;
using Assets.Scripts.Player_Scripts.Powers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public enum BallType
    {
        Fire,
        Ice,
        Lightning
    }
    
    [SerializeField]
    Camera camera;
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    float range = 100f;

    [SerializeField]
    GameObject[] powers = new GameObject[3];

    [SerializeField]
    GameObject currentPower;

    [SerializeField]
    float speed = 10f;

    [SerializeField]
    float angle;
    private readonly string PlayerTag = "Player";

    private void Start()
    {
        currentPower = powers[0];
    }

    public void Shoot()
    {
        GameObject ballEffect = Instantiate(currentPower, transform.position, Quaternion.identity);
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            ShootOnEnemy(ballEffect, hit);
        }
        FindObjectOfType<AudioManager>().Play("FireBall");
    }
    private void ShootOnEnemy(GameObject ballEffect, RaycastHit hit)
    {
        Rigidbody rb = ballEffect.GetComponent<Rigidbody>();
        Vector3 direction = (hit.point - ballEffect.transform.position).normalized;
        rb.velocity = direction * speed;
    }

    public void SetPower(PowerType powerType)
    {
        switch (powerType)
        {
            case PowerType.FireBall:
                currentPower = powers[0];
                break;
            case PowerType.IceBall:
                currentPower = powers[1];
                break;
            case PowerType.LightningBall:
                currentPower = powers[2];
                break;
        }
    }
}
