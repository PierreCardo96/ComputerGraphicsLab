using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance = null;
    [SerializeField]
    Text distanceText;
    [SerializeField]
    ActionBar actionBar;
    [SerializeField]
    Slider healthBarSlider;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    public Text GetDistanceText()
    {
        return distanceText;
    }

    public ActionBar GetActionBar()
    {
        return actionBar;
    }
    
    public Slider GetHealthBarSlider()
    {
        return healthBarSlider;
    }

    public void ResetHealth()
    {
        healthBarSlider.value = 1;
    }

    public void UnselectPowers()
    {
        actionBar.UnselectAll();
    }
}
