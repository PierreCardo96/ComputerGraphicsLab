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
        private void Awake()
        {
            healthBar = FindObjectOfType<PlayerUI>().GetHealthBarSlider();
        }
        protected override void ProcessDeath()
        {
            GetComponentInChildren<PlayerAnimator>().Die();
            GetComponent<DeathHandler>().HandleDeath();
            GetComponent<PlayerInputHandler>().enabled = false;
        }
    }
}
