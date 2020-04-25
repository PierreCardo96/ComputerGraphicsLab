using Assets.Scripts.Player_Scripts.Powers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour
{
    private ActionSlot[] actionSlots;
    private PowerType currentPowerType;

    // Start is called before the first frame update
    void Start()
    {
        actionSlots = GetComponentsInChildren<ActionSlot>();
    }

    public void UpdateSelection(PowerType powerType)
    {
        PowerType lastPowerType = currentPowerType;
        currentPowerType = powerType;
        foreach (ActionSlot actionSlot in actionSlots)
        {
            if(actionSlot.GetPowerType() == lastPowerType)
            {
                actionSlot.UnSelect();
            }
            if(actionSlot.GetPowerType() == currentPowerType)
            {
                actionSlot.Select();
            }
        }
    }

    public bool IsPowerActive(PowerType powerType)
    {
        foreach (ActionSlot actionSlot in actionSlots)
        {
            if (actionSlot.GetPowerType() == powerType)
            {
                return actionSlot.GetIsActive();
            }
        }
        return false;
    }
}
