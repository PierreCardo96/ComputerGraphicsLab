using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    float damage = 30f;

    [SerializeField]
    string opponent;



    protected virtual void OnTriggerEnter(Collider other)
    {
        DamageOponent(other);
    }

    private void DamageOponent(Collider other)
    {
        if (other.gameObject.tag == opponent)
        {
            Health target = other.gameObject.GetComponent<Health>();
            target?.TakeDamage(damage);
        }
    }
}
