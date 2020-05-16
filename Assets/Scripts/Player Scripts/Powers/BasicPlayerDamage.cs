using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerDamage : DamageOnCollision
{
    [SerializeField]
    GameObject hitEffect;

    [SerializeField]
    string UnAffectedTag;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != UnAffectedTag)
        {
            base.OnTriggerEnter(other);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Explosion");
            Destroy(gameObject);
        }
    }
}
