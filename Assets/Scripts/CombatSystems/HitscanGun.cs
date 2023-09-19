using UnityEngine;

public class HitscanGun : MonoBehaviour
{
    public bool isPlayer = false;
    private Rigidbody rb;
    private WeaponManager weaponManager;

    //damage
    public float damage = 10f;
    public float damageModifier = 1; //keep at 1
    private float _baseModifier;
    public float range = 250f; //units

    //suit
    public int selectedAmmoTypeIndex = 0; //0 - no suit, 1, heart, 2 - diamond, 3 - spades, 4 - clubs;
    public int currentAmmoTypeIndex;

    //fireRate
    public float fireRate = 2.5f; //bullets per second
    private float _nextFire = 0f;
    public bool fullAuto;
    public float timeBetweenShots;

    //spread
    public bool shotgun;
    public float spread;
    public int bulletsPerShot = 1;
    private int _bulletsShot;

    //knockback
    private bool knockback = false;
    private float knockbackForce;

    //raycast
    Ray ray;
    RaycastHit hit;

    //critical    
    public Transform raycastOrigin;
    public Transform raycastWeaponOrigin; //used for drawing tracers

    //Ammo    
    public int maxAmmo = 60;
    private int currentAmmo;
    public bool bottomlessClip;
    //UI
    public AmmoCounter ammoCounter;
    public GameObject UI;

    //reloading
    public float reloadSpeed = 1.5f;
    private bool _reloading = false;
    public float readyTime = 5f;
    public bool isReady = true;

    //animations
    public TrailRenderer tracerEffect;
    public ParticleSystem impactEffect;
    public ParticleSystem muzzleFlash;
    public Animator animator;

    void Start()
    {
        //get RB
        rb = GetComponentInParent<Rigidbody>();
        //get weapon manager
        weaponManager = GetComponentInParent<WeaponManager>();

        SetDamage(damageModifier);
        //set ammo
        currentAmmo = maxAmmo;

        if (isPlayer && selectedAmmoTypeIndex == 0)
            selectedAmmoTypeIndex++;
        currentAmmoTypeIndex = selectedAmmoTypeIndex;

        SetUI();
        UpdateUI();

    }
    private void OnEnable()
    {
        SetUI();
        UpdateUI();        

        isReady = false;
        Invoke("ReadyWeapon", readyTime);
    }
    private void OnDisable()
    {
        if(UI != null)
            UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {             

        if (isPlayer && !_reloading)
        {
            //full auto shooting 
            if (fullAuto && (Input.GetButton("Fire1") || Input.GetAxis("Fire1") > 0) && Time.time >= _nextFire)
                PreShoot();
            //semi auto shooting (|| Input.GetAxis("Fire1") > 0 - this code is bugged)
            if (!fullAuto && (Input.GetButtonDown("Fire1") ) && Time.time >= _nextFire)
                PreShoot();
            //reloading
            if (Input.GetButton("Reload") && currentAmmo != maxAmmo)
            {
                StartReload();
            }            

            //cycle suit selection
            if (Input.GetButtonDown("ToggleUp") || Input.GetKeyDown(KeyCode.E))
            {
                AmmoUp();
            }
            if (Input.GetButtonDown("ToggleDown") || Input.GetKeyDown(KeyCode.Q))
            {
                AmmoDown();
            }
           
        }
    }   
    public void ReceiveInput()
    {     
        if (Time.time >= _nextFire && !_reloading)
            PreShoot();
    }
    void PreShoot()
    {
        Debug.Log("Fired gun");

        _nextFire = Time.time + 1f / fireRate;
        if (currentAmmo > 0)
        {
            _bulletsShot = bulletsPerShot;
            Shoot();
            if (!bottomlessClip && shotgun)
            {
                currentAmmo -= 1;                
            }
        }
        else
        {          
            StartReload();
        }
    }
    void Shoot()
    {
        //manage ammo
        if(!bottomlessClip && !shotgun)
            currentAmmo -= 1;
        if (isPlayer && ammoCounter != null)
            UpdateUI();


        muzzleFlash.Play();

        //calculate spread
        float spreadX = Random.Range(-spread, spread);
        float spreadY = Random.Range(-spread, spread);

        Vector3 direction = raycastOrigin.forward + new Vector3(spreadX, spreadY, spreadX);

        //bullet tracers
        ray.origin = raycastWeaponOrigin.position;
        ray.direction = direction;
        if (Physics.Raycast(ray, out hit))
            Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);

        var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);

        //if raycast hits
        if (Physics.Raycast(raycastOrigin.position, direction, out hit, range))
        {
            Debug.Log("Target hit, target: " + hit.collider.name);

            //impact effect
            impactEffect.transform.position = hit.point;
            impactEffect.transform.forward = hit.normal;
            impactEffect.Play();
            //tracer
            tracer.transform.position = hit.point;
             
            Health target = hit.transform.GetComponent<Health>();
            if (target != null)
            {
                target.SetDamageType(currentAmmoTypeIndex);
                target.TakeDamage(damage * damageModifier);
            }
        }
        else
        {
            tracer.transform.position = ray.GetPoint(75);
        }
        //add knockback
        if (knockback)        
            rb.AddForce(-direction.normalized * knockbackForce, ForceMode.Impulse);
       
        //for burst and shotguns
        _bulletsShot--;
        if (_bulletsShot > 0 && currentAmmo != 0) 
        {
            Invoke("Shoot", timeBetweenShots);
        }

        if (animator != null)
        {
            animator.SetTrigger("Shoot");
        }
    }
    
    void StartReload()
    {
        Debug.Log("Reloading: " + reloadSpeed);

        Invoke("Reload", reloadSpeed);        

        _reloading = true;
        isReady = false;
    }
    void Reload()
    {
        Debug.Log("Reloaded");

        currentAmmo = maxAmmo;
        currentAmmoTypeIndex = selectedAmmoTypeIndex;

        if (isPlayer && ammoCounter != null && gameObject.activeInHierarchy)
            UpdateUI();

        _reloading = false;
        isReady = true;
    }
    void AmmoUp()
    {
        selectedAmmoTypeIndex++;
        if (selectedAmmoTypeIndex >= 5)
        {
            selectedAmmoTypeIndex = 1;
        }
    }
    void AmmoDown()
    {
        selectedAmmoTypeIndex--;
        if (selectedAmmoTypeIndex <= 0)
        {
            selectedAmmoTypeIndex = 4;
        }
    }
    public void SetDamage(float stat)
    {
        _baseModifier = stat;
        damageModifier = stat;
    }
    public void ModifyDamage(float modifier)
    {
        //adds modifier to modifier
        damageModifier += modifier;
    }
    public void ResetModifier()
    {
        damageModifier = _baseModifier;
    }
    void ReadyWeapon()
    {
        isReady = true;
    }
    public void SetKnockback(bool isActive, float force)
    {
        knockbackForce = force;
        knockback = isActive;
    }
    
    void SetUI()
    {
        if (ammoCounter != null)ammoCounter.SetMaxAmmo(maxAmmo);
        
        if (UI != null)
            UI.SetActive(true);
    }
    void UpdateUI()
    {
        if (ammoCounter != null)  ammoCounter.SetAmmo(currentAmmo);

        if(weaponManager != null)
            weaponManager.UpdateAmmoUI();

    }

}
