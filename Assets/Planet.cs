using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    float gravity = -10f;

    public void Attract(Transform mass)
    {
        Vector3 targetDirection = (mass.position - transform.position).normalized;
        Vector3 massCurrentDirection = mass.up;

        mass.rotation = Quaternion.FromToRotation(massCurrentDirection, targetDirection) * mass.rotation;//Adding the addition rotation to the current rotation
        mass.GetComponent<Rigidbody>().AddForce(targetDirection * gravity);//attract the mass to the planet
    }
}
