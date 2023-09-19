using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool isPlayer = false;

    private Rigidbody _rigidbody;
    public GameObject explosionEffect;
    [Tooltip("Decides whether the bullet will effect objects hit")]    

    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    //explosion
    public int explosionDamage;
    public float explosionRange;
    public int _AmmoTypeIndex;

    //modifiers
    public float damageModifier = 0; //keep at 0
    

    //lifetime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch;
    private int collisions;

    PhysicMaterial physicsMat;
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //manage lifetime
        if (collisions >= maxCollisions)
            Explode();
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0)
            Explode();
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        
            collisions++;
            
            if (isPlayer)
            {
                if (collision.collider.CompareTag("Player"))
                    return;

                if (collision.collider.CompareTag("Enemy") && explodeOnTouch)
                    Explode();
            }
            else
            {
                if (collision.collider.CompareTag("Enemy"))
                    return;

                if (collision.collider.CompareTag("Player") && explodeOnTouch)
                    Explode();
            }
        
    }
    
    void Setup()
    {
        _rigidbody = GetComponent<Rigidbody>();

        //set physics
        physicsMat = new PhysicMaterial();
        physicsMat.bounciness = bounciness;
        physicsMat.frictionCombine = PhysicMaterialCombine.Minimum;
        physicsMat.bounceCombine = PhysicMaterialCombine.Maximum;
        GetComponent<SphereCollider>().material = physicsMat;

        _rigidbody.useGravity = useGravity;
    }
    void Explode()
    {
        if(explosionEffect != null)
        {
            GameObject explosionGO = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosionGO, 2f);
        }

        Collider[] targets = Physics.OverlapSphere(transform.position, explosionRange);
        for(int i = 0; i < targets.Length; i++)
        {
            if (targets[i].GetComponent<Health>())
            {
                targets[i].GetComponent<Health>().SetDamageType(_AmmoTypeIndex);
                targets[i].GetComponent<Health>().TakeDamage(explosionDamage * damageModifier);
            }
        }
        Destroy(gameObject);
    }
    public void ModifyDamage(float modifier)
    {
        //adds modifier to modifier
        damageModifier += modifier;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
    

}
