using Assets.Scripts.Player_Scripts.Powers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSlot : MonoBehaviour
{
    [SerializeField]
    private PowerType powerType = PowerType.FireBall;
    private RawImage powerImage;
    private RawImage[] borders;

    [SerializeField]
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        powerImage = GetComponent<RawImage>();
        borders = GetComponentsInChildren<RawImage>();
    }

    public void Select()
    {
        ColorBorders(Color.red);
    }

    public void UnSelect()
    {
        ColorBorders(Color.yellow);
    }

    private void ColorBorders(Color color)
    {
        borders[1].color = color;
        borders[2].color = color;
    }


    public PowerType GetPowerType()
    {
        return powerType;
    }

    public bool GetIsActive()
    {
        return isActive;
    }
}
