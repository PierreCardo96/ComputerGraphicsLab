using Assets.Scripts.Player_Scripts.Powers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersHotkey : MonoBehaviour
{

    [SerializeField]
    ActionBar actionBar;
    private BallShooter ballShooter;
    
    private void Start()
    {
        ballShooter = GetComponentInChildren<BallShooter>();
    }

    public void RespondToHotKey()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ProcessPowerPressed(PowerType.FireBall);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ProcessPowerPressed(PowerType.IceBall);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ProcessPowerPressed(PowerType.LightningBall);
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            actionBar.SetAllPowersActivation(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            actionBar.SetAllPowersActivation(false);
        }
    }

    private void ProcessPowerPressed(PowerType powerType)
    {
        if (actionBar.IsPowerActive(powerType))
        {
            actionBar.UpdateSelection(powerType);
            ballShooter.SetPower(powerType);
        }
    }
}
