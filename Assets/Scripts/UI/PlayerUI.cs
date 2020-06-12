using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance = null;
    [SerializeField]
    ActionBar actionBar;
    [SerializeField]
    Slider healthBarSlider;
    [SerializeField]
    private Text healthText;

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

    public ActionBar GetActionBar()
    {
        return actionBar;
    }
    
    public Slider GetHealthBarSlider()
    {
        return healthBarSlider;
    }
    public Text GetHealthText()
    {
        return healthText;
    }

    public void ResetHealth()
    {
        healthBarSlider.value = 1;
        healthText.text = "Health: 100";
    }
    
    public void UnselectPowers()
    {
        actionBar.UnselectAll();
    }

    public void SetAllPowersActivation(bool value)
    {
        actionBar.SetAllKeysActivation(value);
    }
}
