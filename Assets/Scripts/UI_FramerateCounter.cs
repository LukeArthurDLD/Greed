using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_FramerateCounter : MonoBehaviour
{
    public TMP_Text frameRate;
    public int frames;
    private int _framesRefreshCounter;

    // Update - Framerate
    void Update()
    {
        _framesRefreshCounter += Time.frameCount;
        frameRate.text = frames.ToString();

        if (_framesRefreshCounter >= 1000)
        {
            _framesRefreshCounter = 0;

            float _currentFrameRate = 0;
            _currentFrameRate = Time.frameCount / Time.time;
            frames = (int)_currentFrameRate;
            
        }
    }
}
