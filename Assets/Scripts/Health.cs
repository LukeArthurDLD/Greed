using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float _currentHealth;

    //regen
    public bool regenerates = false;
    [Range(0, 1)]
    public float regenRate = 0f;
    private float _baseRegenRate;
    public float regenDelay = 2f;
    private float _baseRegenDelay;
    private Coroutine regen;

    public float armourModifier = 1;
    private float _baseModifier;

    //healthbar
    public HealthBar healthBar;

    //suit
    public int suitIndex = 0; //0 - no suit, 1, heart, 2 - diamond, 3 - spades, 4 - clubs;
    private bool _isRed;
    [Range(0,1)]
    public float suitModifier = .75f, colourModifier = .50f;       
    private float _damageModifier;
    private int _damageTypeIndex;

    private bool _isDead = false;

    public bool selfDestroys;

    private AudioSource _audioSource;
    public AudioClip damagedSound;

    // Start is called before the first frame update
    void Start()
    {
        SetArmour(armourModifier);

        _baseRegenDelay = regenDelay;
        _baseRegenRate = regenRate;

        _currentHealth = maxHealth;
        _audioSource = GetComponent<AudioSource>();
        if (healthBar != null)
            SetUI();

        SetColours();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && Input.GetKeyDown(KeyCode.J) && tag.Contains("Player"))
            _currentHealth += 1000;       

    }
    private IEnumerator RegenHP(bool isBuff = false)
    {
        yield return new WaitForSeconds(regenDelay);

        while(_currentHealth < maxHealth)
        {
            _currentHealth += maxHealth / 100;
            UpdateUI();
            yield return new WaitForSeconds(regenRate);
        }
        if (!isBuff)
            regen = null;
    }
  
   
    public void Heal(float heal)
    {
        if (_currentHealth < maxHealth)
        {
            _currentHealth += heal;
            if (_currentHealth > maxHealth)
            {
                _currentHealth = maxHealth;
            }
            if (healthBar != null)
                UpdateUI();
        }
    }

    public void TakeDamage(float damage)
    {
        if (!_isDead)
        {
            
            if (_audioSource)
            {
                _audioSource.clip = damagedSound;
                _audioSource.Play();
            }
            //suitdamage
            if (_damageTypeIndex == suitIndex || suitIndex == 0)
            {
                _damageModifier = 1;
            }
            else if (_damageTypeIndex != suitIndex)
            {
                _damageModifier = CheckSuits();
            }
            //applys modifier
            damage = damage * _damageModifier;

            //damage is done            
             _currentHealth -= (damage * armourModifier);
            if (healthBar != null)
                UpdateUI();

            //health is capped
            if (_currentHealth < 0)
                _currentHealth = 0;
            //destroys
            if (_currentHealth == 0 && selfDestroys)
            {
                Destroy(gameObject);
                _isDead = true;
            }

            //regen
            if (regenerates && _currentHealth != maxHealth)
            {
                if (regen != null)
                    StopCoroutine(regen);

                regen = StartCoroutine(RegenHP());
            }
        }
    }   
    public void SetDamageType(int index)
    {
        _damageTypeIndex = index;
    }
    public void SetArmour(float stat)
    {
        _baseModifier = stat;
        armourModifier = stat;
    }
    public void ModifyArmour(float modifier)
    {
        //modifier
        armourModifier += modifier;
    }
    public void ModifyRegen(float modifier)
    {
        regenDelay = 0;
        regenRate = modifier;        
        
        regen = StartCoroutine(RegenHP(true));

    }
    public void ResetModifier()
    {
        regenDelay = _baseRegenDelay;
        regenRate = _baseRegenRate;
        armourModifier = _baseModifier;

        if (regen != null)
            StopCoroutine(regen);
        regen = StartCoroutine(RegenHP());

    }
    float CheckSuits()
    {      
        if ((_isRed && _damageTypeIndex == 3) || (_isRed && _damageTypeIndex == 4) ||
            (!_isRed && _damageTypeIndex == 1) || (!_isRed && _damageTypeIndex == 2))
            return colourModifier;
        
        if(suitIndex != _damageTypeIndex)
        {
            if((suitIndex == 1 && _damageTypeIndex == 2) || (suitIndex == 2 && _damageTypeIndex == 1) ||
                (suitIndex == 3 && _damageTypeIndex == 4) || (suitIndex == 4 && _damageTypeIndex == 3))
            {
                return suitModifier;
            }
           
        }
        return 1;
    }
    void SetColours()
    {
        if (suitIndex == 1 || suitIndex == 2)
            _isRed = true;
        else if (suitIndex == 3 || suitIndex == 4)
            _isRed = false;

    }
    void SetUI()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(_currentHealth);
    }
    void UpdateUI()
    {
        healthBar.gameObject.SetActive(true);
        healthBar.SetHealth(_currentHealth);
    }

}
