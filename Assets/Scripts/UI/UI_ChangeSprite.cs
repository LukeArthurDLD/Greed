using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_ChangeSprite : MonoBehaviour
{
    public Sprite restingImage;
    public Sprite activeImage;

    private Image im;

    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<Image>();
    }

    public void ResetImage()
    {
        im.sprite = restingImage;
    }

    public void ChangeImage()
    {
        im.sprite = activeImage;
    }
}
