using Assets.Scripts;
using Assets.Scripts.Player_Scripts.Powers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    
    [SerializeField]
    Camera camera;
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    float range = 100f;

    [SerializeField]
    GameObject[] powers = new GameObject[4];

    [SerializeField]
    GameObject currentPower;

    [SerializeField]
    float speed = 10f;

    [SerializeField]
    float angle;
    private PowerType currentPowerType = PowerType.WhiteBall;
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
        PlayShootingSound();
    }

    private void PlayShootingSound()
    {
        switch(currentPowerType)
        {
            case PowerType.WhiteBall:
                FindObjectOfType<AudioManager>().Play("WhiteBall");
                break;
            case PowerType.FireBall:
                FindObjectOfType<AudioManager>().Play("FireBall");
                break;
            case PowerType.IceBall:
                FindObjectOfType<AudioManager>().Play("IceBall");
                break;
            case PowerType.LightningBall:
                FindObjectOfType<AudioManager>().Play("LightningBall");
                break;
        }
        
    }

    private void ShootOnEnemy(GameObject ballEffect, RaycastHit hit)
    {
        Rigidbody rigidBody = ballEffect.GetComponent<Rigidbody>();
        Vector3 direction = (hit.point - ballEffect.transform.position).normalized;
        rigidBody.velocity = direction * speed;
    }

    public void SetPower(PowerType powerType)
    {
        currentPowerType = powerType;
        switch (currentPowerType)
        {
            case PowerType.WhiteBall:
                currentPower = powers[0];
                break;
            case PowerType.FireBall:
                currentPower = powers[1];
                break;
            case PowerType.IceBall:
                currentPower = powers[2];
                break;
            case PowerType.LightningBall:
                currentPower = powers[3];
                break;
        }
    }

    public PowerType GetCurrentPowerType()
    {
        return currentPowerType;
    }
}
