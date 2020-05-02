using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100f;
    protected Slider healthBar;

    [SerializeField]
    Animator animator;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public float GetHealth()
    {
        return healthBar.value;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth / maxHealth;
        if(healthBar.value <= 0)
        {
            ProcessDeath();
        }
    }

    protected virtual void ProcessDeath()
    {
        animator.SetBool("isDead", true);
    }
}
