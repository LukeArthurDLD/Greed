using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Twitch : MonoBehaviour
{
    public RectTransform restingPosition;
    public RectTransform[] transitionPositions;
    public RectTransform endPosition;

    public int slideDistance;

    private RectTransform _rectTransform;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Twitch();
    }

    public void ResetImage()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    public void Twitch()
    {
        this.GetComponent<RectTransform>().anchoredPosition += new Vector2(slideDistance, 0);

        this.GetComponent<RectTransform>().anchoredPosition -= new Vector2(slideDistance, 0);

        this.GetComponent<RectTransform>().anchoredPosition -= new Vector2(slideDistance, 0);

        this.GetComponent<RectTransform>().anchoredPosition += new Vector2(slideDistance, 0);
    }
}
