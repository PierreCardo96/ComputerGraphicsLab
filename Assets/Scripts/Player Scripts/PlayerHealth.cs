using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerHealth : Health
    {
        //private void Awake()
        //{
        //    healthBar = PlayerUI.Instance.GetHealthBarSlider();
        //}

        private void Start()
        {
            healthBar = PlayerUI.Instance.GetHealthBarSlider();
        }

        public void IncreaseHealth(int healthAmount)
        {
            currentHealth += healthAmount;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            healthBar.value = currentHealth / maxHealth;
        }

        protected override void ProcessDeath()
        {
            GetComponentInChildren<PlayerAnimator>().Die();
            GetComponent<DeathHandler>().HandleDeath();
            GetComponent<PlayerInputHandler>().enabled = false;
        }
    }
}
