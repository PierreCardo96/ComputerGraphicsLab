﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class PlayerHealth : Health
    {
        protected override void ProcessDeath()
        {
            base.ProcessDeath();
            //FindObjectOfType<MouseMovement>().enabled = false;
            //FindObjectOfType<FireBallSpawner>().enabled = false;
            GetComponent<PlayerInputHandler>().enabled = false;
        }
    }
}
