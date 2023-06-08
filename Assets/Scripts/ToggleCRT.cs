using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCRT : MonoBehaviour
{
    public void CRTToggle()
    {
        if (QualitySettings.GetQualityLevel() < 5)
        {
            QualitySettings.SetQualityLevel(5);
        }
        else
        {
            QualitySettings.SetQualityLevel(4);
        }
    }
}
