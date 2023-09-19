using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_UserInterface : MonoBehaviour
{
    [Header("Parent Script")][SerializeField]
    internal Settings_System settingsSystemManager;

    internal float frameRate;
    
    void Update()
    {
        if (settingsSystemManager.frameRateCounter == true)
        {
            CalculateFrameRate();
        }
    }

    void CalculateFrameRate()
    {
        frameRate = (int)(1f / Time.unscaledDeltaTime);
        Debug.Log("Frames: " + frameRate);
    }
}
