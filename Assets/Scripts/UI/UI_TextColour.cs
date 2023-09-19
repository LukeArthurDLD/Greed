using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_TextColour : MonoBehaviour
{
    private TMP_Text tmpText;
    private RectTransform rect;

    public TMP_Text textObject;

    public int frames;

    private Color c;

    private float colorR = 0;
    private float colorG = 0;
    private float colorB = 0;
    private float colorA = 255;

    // Start is called before the first frame update
    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        rect = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        frames += (Time.frameCount);

        if (frames >= 100000)
        {
            frames = 0;

        }
    }

    public void ChangeColor()
    {

    }
    private void ResetColorPresets()
    {
        colorR = 0;
        colorG = 0;
        colorB = 0;
        colorA = 0;
    }

    public void EntrySign()
    {
        colorR = 0;
        colorG = 255;
        colorB = 255;
        colorA = 255;
    }

    public void SettingsSign()
    {
        colorR = 0;
        colorG = 255;
        colorB = 255;
        colorA = 255;
    }

    public void NeonOn()
    {   
        VertexGradient textGradient = textObject.GetComponent<TMP_Text>().colorGradient;

        textGradient.bottomLeft = new Color32(0, 0, 255, 255);

        textGradient.bottomRight = new Color32(0, 0, 255, 255);

        textGradient.bottomLeft = new Color32(0, 0, 255, 255);

        textGradient.bottomRight = new Color32(0, 0, 255, 255);

        textObject.GetComponent<TMP_Text>().colorGradient = textGradient;
    }

    public void NeonOff()
    {
        VertexGradient textGradient = textObject.GetComponent<TMP_Text>().colorGradient;

        textGradient.bottomLeft = new Color32(0, 255, 255, 255);

        textGradient.bottomRight = new Color32(0, 255, 255, 255);

        textGradient.bottomLeft = new Color32(0, 255, 255, 255);

        textGradient.bottomRight = new Color32(0, 255, 255, 255);

        textObject.GetComponent<TMP_Text>().colorGradient = textGradient;
    }

    public void RandomizeColorG()
    {   
        int _rand = Random.Range(0, 3);

        if (_rand == 0)
        {
            colorG = 255;
        }
        else if (_rand == 1)
        {
            colorG = 127;
        }
        else
        {
            colorG = 0;
        } 
    }

    public void RandomizeColorB()
    {
        int _rand = Random.Range(0, 3);

        if (_rand == 0)
        {
            colorB = 255;
        }
        else if (_rand == 1)
        {
            colorB = 127;
        }
        else
        {
            colorB = 0;
        }
    }
}
