using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WeaponHolster : MonoBehaviour
{
    // Weapon Index
    int _shotgunIndex = 0;
    int _tommyGunIndex = 1;
    int _revolverIndex = 2;

    void Start()
    {
        if (tag.Contains("Player"))
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    private void Update()
    {
            WeaponChangeUI();
    }

    public void WeaponChangeUI()
    {
        if (tag.Contains("Shotgun"))
            gameObject.transform.GetChild(0).GetChild(_shotgunIndex).gameObject.SetActive(true);
        else if (tag.Contains("Tommy Gun"))
            gameObject.transform.GetChild(0).GetChild(_tommyGunIndex).gameObject.SetActive(true);
        else
            gameObject.transform.GetChild(0).GetComponent<HorizontalLayoutGroup>().padding.left = 100;
            gameObject.transform.GetChild(0).GetChild(_revolverIndex).gameObject.SetActive(true);
    }
}
