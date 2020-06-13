using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class EnemyHealth : Health
    {
        [SerializeField]
        float destructionDelay = 1f;

        [SerializeField]
        Slider healthBarSlider;

        [SerializeField]
        HealthPickup healthBottle;

        [SerializeField]
        float healthSpawningProbability = 0.2f;



        private void Start()
        {
            healthBar = healthBarSlider;
        }
        protected override void ProcessDeath()
        {
            SpawnHealthBottleWithProbability();
            DisableDeadBodyCollider();

            GetComponent<EnemyAnimator>().Die();
            Destroy(gameObject, destructionDelay);
        }

        private void DisableDeadBodyCollider()
        {
            GetComponent<Rigidbody>().drag = 100;
            GetComponent<Rigidbody>().angularDrag = 0.05f;
            GetComponent<CapsuleCollider>().enabled = false;
        }

        private void SpawnHealthBottleWithProbability()
        {
            if (Random.value < healthSpawningProbability)
            {
                Instantiate(healthBottle, transform.position, Quaternion.identity);
            }
        }
    }
}
