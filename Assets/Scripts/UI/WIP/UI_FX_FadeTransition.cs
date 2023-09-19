using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FX_FadeTransition : MonoBehaviour
{
    private bool _faded = false;

    public CanvasGroup uiElement;

    public float duration = 0.4f;

    public float sAlpha = 1f;
    public float eAlpha = 0f;

    public void FadeOut()
    {
        StartCoroutine(DoFade(uiElement, uiElement.alpha, 0f));

        // Toggle Faded State
        _faded = !_faded;
    }

    public void FadeIn()
    {
        StartCoroutine(DoFade(uiElement, uiElement.alpha, 1f));

        // Toggle Faded State
        _faded = !_faded;
    }

    public IEnumerator DoFade(CanvasGroup _cg, float start, float end, float lerpTime = 0.5f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float _currentValue = Mathf.Lerp(start, end, percentageComplete);

            _cg.alpha = _currentValue;

            if (percentageComplete >= 1f)
            {
                break;
            }

            // Runs at speed of an Update()
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Screen fade done!");
    }
}
