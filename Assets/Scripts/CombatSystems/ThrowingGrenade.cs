using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingGrenade : MonoBehaviour
{
    public GameObject bomb;
    //physics
    public float forwardForce;
    public float upwardForce;

    //throwtimes
    public float throwCooldown;
    private float _nextThrow = 0f;  

    //raycasts
    Ray ray;
    RaycastHit hit;

    //cap[acity
    public int maxCapacity;
    public int grenadeCount;
    

    //reloading
    public float rechargeSpeed = 1.5f;
    private bool _recharging = false;
        
    //targetting
    public Transform raycastOrigin;
    public Transform grenadeSpawn;    
    // Start is called before the first frame update
    void Start()
    {
        grenadeCount = maxCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire2") || Input.GetAxis("Fire2") > 0) && Time.time >= _nextThrow)
        {
            PreThrow();
        }

        Recharge();
    }
    void PreThrow()
    {
        _nextThrow = Time.time + 1f / throwCooldown;
        if(grenadeCount > 0)
        {
            Throw();
        }
    }

    void Throw()
    {
        grenadeCount--;

        //find hit position     
        ray.origin = raycastOrigin.position;       

        //checks if ray hits
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        //instatiates projectile
        GameObject currentGrenade = Instantiate(bomb, grenadeSpawn.position, Quaternion.identity);
        currentGrenade.transform.forward = raycastOrigin.forward.normalized;

        //applies modifier
        currentGrenade.GetComponent<Projectile>().ModifyDamage(1);

        //adds force to projectile
        currentGrenade.GetComponent<Rigidbody>().AddForce(raycastOrigin.forward.normalized * forwardForce, ForceMode.Impulse);
        currentGrenade.GetComponent<Rigidbody>().AddForce(raycastOrigin.transform.up * upwardForce, ForceMode.Impulse);

    }
    void Recharge()
    {
        if (grenadeCount != maxCapacity && !_recharging)
        {
            Invoke("AddCharge", rechargeSpeed);
            _recharging = true;
        }
    }
    void AddCharge()
    {
        grenadeCount++;
        _recharging = false;
    }

}
