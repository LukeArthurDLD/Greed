using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    public GameObject projectile;

    public bool isPlayer = false;
    private Rigidbody rb;

    //physics
    public float forwardForce;
    public float upwardForce;

    public float damageModifier = 1; //keep at 1
    private float _baseModifier;

    //firerate
    public float fireRate;
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

    //raycasts
    Ray ray;
    RaycastHit hit;

    //ammo
    public int maxAmmo;
    private int currentAmmo;
    public bool bottomlessClip;
    //UI
    public AmmoCounter ammoCounter;
    
    //reloading
    public float reloadSpeed = 1.5f;
    private bool _reloading = false;
    public float readyTime = 0.5f;    
    public bool isReady = true;

    //suit
    public int selectedAmmoTypeIndex = 0;
    public int currentAmmoTypeIndex;
    
    //animations
    public ParticleSystem muzzleFlash;

    //targetting
    public Transform raycastOrigin;
    public Transform projectileSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //get RB
        rb = GetComponentInParent<Rigidbody>();

        SetDamage(damageModifier);
        
        //set ammo
        currentAmmo = maxAmmo;
        SetUI();

        if (isPlayer && selectedAmmoTypeIndex == 0)
            selectedAmmoTypeIndex++;
        currentAmmoTypeIndex = selectedAmmoTypeIndex;
    }
    private void OnEnable()
    {
        SetUI();
        UpdateUI();

        isReady = false;
        Invoke("ReadyWeapon", readyTime);
    }

    // Update is called once per frame
    void Update()
    {
     
        if (isPlayer && !_reloading)
        {
            //full auto shooting
            if (fullAuto && Input.GetButton("Fire1") && Time.time >= _nextFire)
                PreShoot();
            //semi auto shooting
            if (!fullAuto && Input.GetButtonDown("Fire1") && Time.time >= _nextFire)
                PreShoot();
            //reloading
            if (Input.GetButton("Reload") && currentAmmo != maxAmmo)            
                StartReload();            

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
                currentAmmo -= 1;    
        }
        else
        {
            StartReload();
        }
    }

    void Shoot()
    {
        //manageAmmo
        if(!bottomlessClip && !shotgun)
            currentAmmo -= 1;
        //updateUI
        if (isPlayer && ammoCounter != null)
            UpdateUI();

        muzzleFlash.Play();

        //calculate spread
        float spreadX = Random.Range(-spread, spread);
        float spreadY = Random.Range(-spread, spread);

        Vector3 direction = raycastOrigin.forward + new Vector3(spreadX, spreadY, spreadX);

        //find hit position     
        ray.origin = raycastOrigin.position;
        ray.direction = direction;
        
        //checks if ray hits
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        //instatiates projectile
        GameObject currentProjectile = Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
        currentProjectile.transform.forward = direction.normalized;
        if (isPlayer)
            currentProjectile.GetComponent<Projectile>().isPlayer = true;

        //adds ammotype to projectile
        currentProjectile.GetComponent<Projectile>()._AmmoTypeIndex = selectedAmmoTypeIndex;
        //adds modifier to projectile
        currentProjectile.GetComponent<Projectile>().ModifyDamage(damageModifier);

        //adds force to projectile
        currentProjectile.GetComponent<Rigidbody>().AddForce(direction.normalized * forwardForce, ForceMode.Impulse);
        currentProjectile.GetComponent<Rigidbody>().AddForce(raycastOrigin.transform.up * upwardForce, ForceMode.Impulse);

        if (knockback)        
            rb.AddForce(-direction.normalized * knockbackForce, ForceMode.Impulse);
       

        //for bursts and shotguns
        _bulletsShot--;
        if(_bulletsShot > 0 && currentAmmo != 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }
    void StartReload()
    {
        Debug.Log("Reloading: " + reloadSpeed);

        Invoke("Reload", reloadSpeed);        

        _reloading = true;
        isReady = true;
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
        if (ammoCounter != null) 
            ammoCounter.SetMaxAmmo(maxAmmo);
    }
    void UpdateUI()
    {
        if (ammoCounter != null)
            ammoCounter.SetAmmo(currentAmmo);
    }

}
