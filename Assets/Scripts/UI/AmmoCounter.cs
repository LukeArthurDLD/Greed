using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public Slider slider;
    public Text text;
   
    public void SetMaxAmmo(int ammo)
    {
        slider.maxValue = ammo;
        SetAmmo(ammo);
    }
    public void SetAmmo(int ammo)
    {
        slider.value = ammo;   
        if (text != null)
            text.text = slider.value.ToString();
    }
   
}
