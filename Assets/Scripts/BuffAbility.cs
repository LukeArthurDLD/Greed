    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAbility : MonoBehaviour
{   
    public float buffDuration = 5;

    public bool isActive = false;
    private bool _isReady = true;

    //buffs
    [Range(-1, 2)][Tooltip("For multiplying the variables; -0.5 is half, 0 is unchanged, 1 is doubled")]
    public float minSpeedModifier = 1, maxSpeedModifier = 1, minDamageModifier = 1, maxDamageModifier = 1, minArmourResistance = 1, maxArmourResistance = 1;
    private float _speedModifier, _damageModifier, _armourResistance;

    [Range(0,1)][Tooltip("Seconds between each regentick")]
    public float regenRate = 0f;

    //maxUses
    [Tooltip("How many charges of the ability can be stored")]
    public int maxCharges = 1;
    public int charges = 1;

    //recharge
    [Tooltip("How long the ability to gain charges")]
    public float rechargeSpeed = 5f;
    private bool _recharging = false;

    public Transform player;
    //movement handler
    private PlayerScript _playerScript;
    //weapon handler    
    private WeaponManager _weaponManager;
    //health handler
    private Health _health;


    // Start is called before the first frame update
    void Start()
    {
        
        //assigns handlers
        _weaponManager = player.GetComponentInChildren<WeaponManager>();
        _health = player.GetComponent<Health>();
        _playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive || charges == 0)
            _isReady = false;
        else
            _isReady = true;

       if (Input.GetKeyDown(KeyCode.B) && _isReady)
        {
            int buffIndex = Random.Range(1, 6);
            Debug.Log("buff index is: " + buffIndex);
            
            RandomiseVariables();            

            ActivateBuff(buffIndex);
        }
        Recharge();
    }
    void RandomiseVariables()
    {
        _damageModifier = Random.Range(minDamageModifier, maxDamageModifier);
        if (_damageModifier == 0)
            _damageModifier = 0.5f;
        _speedModifier = Random.Range(minSpeedModifier, maxDamageModifier);
        if (_speedModifier == 0)
            _speedModifier = 0.5f;
        _armourResistance = Random.Range(minArmourResistance, maxArmourResistance);
        if (_armourResistance == 0)
            _armourResistance = 1f;
    }

    void ActivateBuff(int index)
    {
        isActive = true;
        charges--;

        if (index == 1 || index == 4)
            _weaponManager.WeaponBuff(_damageModifier);
        if (index == 2 || index == 4)
            _playerScript.ModifySpeed(_speedModifier);
        if (index == 3 || index == 4)
            _health.ModifyArmour(_armourResistance);
        if (index == 5)
            Debug.Log("Luck is not on your side.");
        else if (index == 6 || index == 4)
            _health.ModifyRegen(regenRate);


        //deactivate
        Invoke("DeactivateBuff", buffDuration);
    }
    void DeactivateBuff()
    {
        isActive = false;

        _weaponManager.ResetModifier();
        _playerScript.ResetModifier();
        _health.ResetModifier();

    }
    void Recharge()
    {
        if(charges != maxCharges && !_recharging)
        {
            Invoke("AddCharge", rechargeSpeed);
            _recharging = true;
        }
    }
    void AddCharge()
    {
        charges++;
        _recharging = false;
    }
}
