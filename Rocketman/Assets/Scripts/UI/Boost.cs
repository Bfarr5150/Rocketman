using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{

    public Slider BoostBar;

    public void SetMaxBoost(float boost)
    {
        BoostBar.maxValue = boost;
        BoostBar.value = boost;
    }

    public void SetBoost(float boost)
    {
        BoostBar.value = boost;
    }
}
