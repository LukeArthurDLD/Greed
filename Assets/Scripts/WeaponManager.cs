using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float swapTime = 1;
    bool isSwapping = false;

    public float knockbackforce;

    private int _currentWeapon = 0;
    private int _previousWeapon;
    public Transform[] weapons;
    public Transform weaponCam;

    public GameObject[] ammoTypeUI;

    private void Start()
    {
        ChangeWeapon(_currentWeapon); //set default
        UpdateAmmoUI();
        
    }

    void Update()
    {
        if (!isSwapping)
        {
            //keyboard input
            for (int i = 1; i <= weapons.Length; i++)
            {
                if (Input.GetKeyDown("" + i))
                {
                    _currentWeapon = i - 1;

                    ChangeWeapon(_currentWeapon);
                }
            }
            //scroll wheel input
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                _currentWeapon++;
                if (_currentWeapon > weapons.Length - 1) //cycles weapon to first 
                    _currentWeapon = 0;

                ChangeWeapon(_currentWeapon);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                _currentWeapon--;
                if (_currentWeapon < 0) //cycles weapon to first 
                    _currentWeapon = weapons.Length - 1;

                ChangeWeapon(_currentWeapon);
            }
            if (Input.GetAxis("SwitchWeapon") > 0f)
            {
                _currentWeapon++;
                if (_currentWeapon > weapons.Length - 1) //cycles weapon to first 
                    _currentWeapon = 0;

                ChangeWeapon(_currentWeapon);
            }
            if (Input.GetAxis("SwitchWeapon") < 0f)
            {
                _currentWeapon--;
                if (_currentWeapon < 0) //cycles weapon to first 
                    _currentWeapon = weapons.Length - 1;

                ChangeWeapon(_currentWeapon);
            }

        }

    }

    void ChangeWeapon(int index)
    {
        if (_previousWeapon != index)
        {
            isSwapping = true;

            _previousWeapon = index;
            _currentWeapon = index;
            for (int i = 0; i < weapons.Length; i++)
            {
                if (i == index)
                    weapons[i].gameObject.SetActive(true);
                else
                    weapons[i].gameObject.SetActive(false);
            }
            UpdateAmmoUI();
            Invoke("WeaponSwapped", swapTime);
        }
    }
    public void WeaponBuff(float modifier)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].gameObject.GetComponent<HitscanGun>().enabled == true)
                weapons[i].gameObject.GetComponent<HitscanGun>().ModifyDamage(modifier);
            else if (weapons[i].gameObject.GetComponent<ProjectileGun>().enabled == true)
                weapons[i].gameObject.GetComponent<ProjectileGun>().ModifyDamage(modifier);
        }
    }    
    public void ResetModifier()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].gameObject.GetComponent<HitscanGun>().enabled == true)
                weapons[i].gameObject.GetComponent<HitscanGun>().ResetModifier();
            else if (weapons[i].gameObject.GetComponent<ProjectileGun>().enabled == true)
                weapons[i].gameObject.GetComponent<ProjectileGun>().ResetModifier();
        }
    }
    public void SetWeaponDamage(float modifier)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].gameObject.GetComponent<HitscanGun>().enabled == true)
                weapons[i].gameObject.GetComponent<HitscanGun>().SetDamage(modifier);
            else if (weapons[i].gameObject.GetComponent<ProjectileGun>().enabled == true)
                weapons[i].gameObject.GetComponent<ProjectileGun>().SetDamage(modifier);
        }
    }
    public void WeaponSwapped()
    {
        isSwapping = false;
    }
    public void SetProjectile(bool isProjectile)
    {
        if (isProjectile)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].gameObject.GetComponent<HitscanGun>().enabled = false;
                weapons[i].gameObject.GetComponent<ProjectileGun>().enabled = true;                
            }
        }
        else if (!isProjectile)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].gameObject.GetComponent<HitscanGun>().enabled = true;
                weapons[i].gameObject.GetComponent<ProjectileGun>().enabled = false;
            }
        }
    }
    public void SetKnockback(bool hasKnockback)
    {                
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].gameObject.GetComponent<HitscanGun>().enabled == true)
                weapons[i].gameObject.GetComponent<HitscanGun>().SetKnockback(hasKnockback, knockbackforce);
            else if (weapons[i].gameObject.GetComponent<ProjectileGun>().enabled == true)
                weapons[i].gameObject.GetComponent<ProjectileGun>().SetKnockback(hasKnockback, knockbackforce);
        }       

    }
    public void ToggleCamera(bool isActive)
    {
        weaponCam.gameObject.SetActive(isActive);
    }
    public void UpdateAmmoUI()
    {
        int currentIndex = weapons[_currentWeapon].gameObject.GetComponent<HitscanGun>().currentAmmoTypeIndex;

        if (currentIndex == 1)
            SetAmmoUI(0);
        else if (currentIndex == 2)
            SetAmmoUI(1);
        else if (currentIndex == 3)
            SetAmmoUI(2);
        else if (currentIndex == 4)
            SetAmmoUI(3);


    }
    void SetAmmoUI(int index)
    {
        for (int i = 0; i < ammoTypeUI.Length; i++)
        {
            if (i == index)
                ammoTypeUI[i].SetActive(true);
            else
                ammoTypeUI[i].SetActive(false);
        }
    }
}
