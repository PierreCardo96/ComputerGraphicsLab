using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerDamage : Damage
{
    [SerializeField]
    GameObject hitEffect;

    [SerializeField]
    string UnAffectedTag;
    protected override void OnTriggerEnter(Collider other)
    {
        print("Player triggered " + other.name);
        if (other.gameObject.tag != UnAffectedTag)
        {
            base.OnTriggerEnter(other);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
