using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawner : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    float range = 100f;
    public GameObject projectile;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        CapsuleCollider collider = GetComponentInParent<CapsuleCollider>();
        GameObject fireBall = Instantiate(projectile, transform.localPosition + collider.center + transform.forward, Quaternion.identity);
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            print("Raycast hit " + hit.transform.name);
            Rigidbody rb = fireBall.GetComponent<Rigidbody>();
            Vector3 direction = (hit.point - fireBall.transform.position).normalized;
            rb.velocity = direction * 10;
        }


    }
}
