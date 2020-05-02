using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    Text distanceText;
    [SerializeField]
    ActionBar actionBar;
    [SerializeField]
    Slider healthBarSlider;

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
}
