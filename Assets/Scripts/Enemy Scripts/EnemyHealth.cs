using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyHealth : Health
    {
        [SerializeField]
        float destructionDelay = 1f;

        protected override void ProcessDeath()
        {
            base.ProcessDeath();
            Destroy(gameObject, destructionDelay);
        }
    }
}
