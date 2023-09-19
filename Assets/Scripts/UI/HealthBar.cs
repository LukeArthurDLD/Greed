using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Text text;
    public Image fill;
    
    public float fillAmount;

    public bool usesGradient;
    public Gradient gradient;
    private void Start()
    {
        if (tag.Contains("Player"))
            gameObject.SetActive(true);
            
        else
            gameObject.SetActive(false);
    }
    public void SetMaxHealth(float health)
    {
       // health = 100f;
       // this.transform.GetChild(0).GetComponent<Image>().fillAmount = health;

         slider.maxValue = health;
         slider.value = health;
         if (text != null)
            text.text = slider.value.ToString();
         if(usesGradient)
            fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float health)
    {
        slider.value = health;

        //this.transform.GetChild(0).GetComponent<Image>().fillAmount = health;

        if (usesGradient)
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (text != null)
        {
            if (slider.value == 0)
                text.text = ("DEAD");
            else
                text.text = slider.value.ToString();
        }
    }
}