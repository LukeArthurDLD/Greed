using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModifierManager : MonoBehaviour
{
    

    //stat modifiers
    public float _speedModifier, _damageModifier, _armourResistance;

    public Transform HUD;
    public Transform player;
    //movement handler
    private PlayerScript _playerScript;
    //weapon handler    
    private WeaponManager _weaponManager;
    //health handler
    private Health _health;
    //ability manager
    private AbilityManager _abilityManager;

    [Header("Gameplay Data")][SerializeField]
    public GameplayData activeGameplayData;

    void Start()
    {
        //assigns handlers
        _weaponManager = player.GetComponentInChildren<WeaponManager>();
        _health = player.GetComponent<Health>();
        _playerScript = player.GetComponent<PlayerScript>();
        _abilityManager = player.GetComponentInChildren<AbilityManager>();

        if (activeGameplayData.activeModifierType == "Damage")
        {
            SetDamage(activeGameplayData.activeModifierMultiplier);
            _damageModifier = activeGameplayData.activeModifierMultiplier;
        }
        else if (activeGameplayData.activeModifierType == "Speed")
        {
            SetSpeed(activeGameplayData.activeModifierMultiplier);
            _speedModifier = activeGameplayData.activeModifierMultiplier;

        }
        else if (activeGameplayData.activeModifierType == "Armour")
        {
            setArmour(activeGameplayData.activeModifierMultiplier);
            _armourResistance = activeGameplayData.activeModifierMultiplier;

        }


        NewtonsThird(false);
        SluggishBullets(false);
        CantStopWontStop(false);
        TunnelVision(false);
        PsychicBullets(false);
        SetAbility(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void AlterStats()
    {
        _weaponManager.SetWeaponDamage(_damageModifier);

        _playerScript.SetSpeed(_speedModifier);

        _health.SetArmour(_armourResistance);

    }
    public void SetDamage(float value = 1)
    {
        _damageModifier = value;
    }
    public void SetSpeed(float value = 1)
    {
        _speedModifier = value;
    }
    public void setArmour(float value = 0.5f)
    {
        _armourResistance = value;
    }
    public void SetAbility(int index = 0)
    {
        _abilityManager.SelectAbility(index);
    }
    public void SluggishBullets(bool isActive)
    {
        if (_weaponManager != null)
            _weaponManager.SetProjectile(isActive);
    }
    public void NewtonsThird(bool isActive)
    {
        if (_weaponManager != null)
            _weaponManager.SetKnockback(isActive);
    }
    public void CantStopWontStop(bool isActive)
    {
        _playerScript.AlwaysForward(isActive);
    }
    public void TunnelVision(bool isActive)
    {
        HUD.gameObject.SetActive(!isActive);
    }
    public void PsychicBullets(bool isActive)
    {
        _weaponManager.ToggleCamera(!isActive);
    }
}
