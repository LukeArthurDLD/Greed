using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_Visual : MonoBehaviour
{
    [Header("Parent Script")][SerializeField]
    internal Settings_System settingsSystemManager;

    public Resolution nativeScreenResolution;

    public bool fullScreenMode = true;

    public int newScreenWidth;
    public int newScreenHeight;

    private int currentScreenWidth;
    private int currentScreenHeight;
    private float currentScreenBrightness;

    int[] _presetScreenWidth = new int[] { 1920, 1600, 1200 };
    int[] _presetScreenHeight = new int[] { 1080, 900, 720 };

    [Range(0f, 2f)] public float brightness = 1f;
    [Range(0f, 2f)] public float contrast = 1f;

    public void SetBrightness(float _value)
    {
        brightness = _value;
    }

    public void ChangeBrightness(float newScreenBrightness)
    {
        Debug.Log("Screen brightness: " + Screen.brightness);

        Screen.brightness = newScreenBrightness;

        // Start - Coroutine
        // StartCoroutine(UpdateScreenBrightness());
    }

    internal IEnumerator UpdateScreenBrightness()
    {
        // Set - Screen Brightness
        //Screen.brightness = brightnessSlider.value;

        // Update - 1 Frame
        yield return null;
    }

    internal IEnumerator UpdateAspectRatio()
    {
        // Set - New Aspect Ratio
        Screen.SetResolution(newScreenWidth, newScreenHeight, fullScreenMode);

        // Update - Screen Width & Height
        currentScreenWidth = newScreenWidth;
        currentScreenHeight = newScreenHeight;

        // Update - 1 Frame
        yield return null;
    }

    IEnumerator UpdateScreenMode()
    {
        // Check - If Screen is Windowed
        if (fullScreenMode == false)
        {
            // Get - Current Display Settings
            Resolution _r = Screen.currentResolution;

            // Set - Screen Resolution
            Screen.SetResolution(_r.width, _r.height, false);

            // Update - 1 Frame
            yield return null;
        }
        else
        {
            // Set - Screen Resolution
            Screen.SetResolution(nativeScreenResolution.width, nativeScreenResolution.height, true);

            // Update - 1 Frame
            yield return null;
        }
    }

    IEnumerator SetupDeviceVisuals()
    {
        // Check - If Device is Using Windows OS
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("Player is on Windows!");

            // Check - If Screen is Full Screen
            if (fullScreenMode == true)
            {
                // Get - Current Display Settings
                // Set - Screen to Windowed Mode
                Resolution _r = Screen.currentResolution;
                Screen.fullScreen = false;
                
                // Update - 2 Frames
                for (int i = 0; i < 2; i++)
                {
                    yield return null;
                }

                // Read - Current Display Resolution
                nativeScreenResolution = Screen.currentResolution;

                // Set - Screen Resolution to r
                Screen.SetResolution(_r.width, _r.height, true);

                // Update - 1 Frame
                yield return null;
            }
            else
            {
                // Read - Current Display Resolution
                nativeScreenResolution = Screen.currentResolution;

                yield return null;
            }
        }

        // Mac Device
        else if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("Player is using a Mac!");
            yield return null;
        }

        // Linux Device
        if (Application.platform == RuntimePlatform.LinuxPlayer)
        {
            Debug.Log("Player is using a Linux Device!");
            yield return null;
        }

        // iPhone Device
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Debug.Log("Player is using an iPhone!");
            yield return null;
        }

        // Android Device
        else if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("Player is on an Android Device!");
            yield return null;
        }

        // Internet App
        else if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Debug.Log("Player is on the Web!");
            yield return null;
        }

        // Nintendo Switch
        else if (Application.platform == RuntimePlatform.Switch)
        {
            Debug.Log("Player is on a Nintendo Switch!");
            yield return null;
        }

        // Xbox One
        else if (Application.platform == RuntimePlatform.XboxOne)
        {
            Debug.Log("Player is on a Xbox One!");
            yield return null;
        }

        // Playstation 4
        else if (Application.platform == RuntimePlatform.PS4)
        {
            Debug.Log("Player is on a Playstation 4!");
            yield return null;
        }

        // Unsupported Device
        else
        {
            Debug.Log("Player is on an unsupported device?");
            yield return null;
        }
    } 

}
