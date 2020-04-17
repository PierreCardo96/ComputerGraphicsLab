using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    Galaxy galaxy;

    [SerializeField]
    float gravity = -10f;

    [SerializeField]
    bool FixedDirection;

    public void Attract(Transform mass)
    {

        Vector3 massCurrentDirection = mass.up;
        Vector3 targetDirection = GetTargetDirection(mass);

        mass.rotation = Quaternion.FromToRotation(massCurrentDirection, targetDirection) * mass.rotation;//Adding the addition rotation to the current rotation
        mass.GetComponent<Rigidbody>().AddForce(targetDirection * gravity);//attract the mass to the planet
    }

    private Vector3 GetTargetDirection(Transform mass)
    {
        Vector3 targetDirection = transform.up;
        if (!FixedDirection)
        {
            targetDirection = (mass.position - transform.position).normalized;
        }
        return targetDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Triggered by " + other.gameObject.name);
        if (other.GetComponent<MassGravity>())
        {
            galaxy.SetPlanetToMass(other.GetComponent<MassGravity>(), this);
        }
    }
}
