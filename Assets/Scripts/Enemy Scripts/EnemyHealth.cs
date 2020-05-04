using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class EnemyHealth : Health
    {
        [SerializeField]
        float destructionDelay = 1f;

        [SerializeField]
        Slider healthBarSlider;
        private void Awake()
        {
            healthBar = healthBarSlider;
        }
        protected override void ProcessDeath()
        {
            GetComponent<EnemyAnimator>().Die();
            Destroy(gameObject, destructionDelay);
        }
    }
}
