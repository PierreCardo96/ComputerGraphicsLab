using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Slider healthBar;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    public float GetHealth()
    {
        return healthBar.value;
    }
}
