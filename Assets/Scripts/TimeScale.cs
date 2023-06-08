using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScale : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    public void TimeScaleSet()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
            text.text = "Stop";
        }
        else
        {
            Time.timeScale = 0;
            text.text = "Play";
        }
    }
}
