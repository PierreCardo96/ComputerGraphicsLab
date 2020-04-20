using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MassGravity : MonoBehaviour
{
    public Planet planet;
    private void Awake()
    {
        TurnOffPhysics();
    }

    private void TurnOffPhysics()
    {
        GetComponent<Rigidbody>().useGravity = false; //turn of the gravity to the "original planet" 
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; //we rotate the rotations of the mass manually by the planet
    }

    //Called Multiple times per frame in a constant rate
    private void FixedUpdate()
    {
       planet.Attract(transform);
    }
}
