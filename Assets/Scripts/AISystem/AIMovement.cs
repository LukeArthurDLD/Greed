using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{

    public NavMeshAgent navAgent;
    public Transform player;
    private Health health;

    public LayerMask whatIsGround, whatIsPlayer, whatIsEnemy;

    //patrolling
    public bool patrols;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //FOV functions
    public float detectionRadius;
    [Range(0, 360)]
    public float detectionFOV;
    bool hasAlerted = false;


    //states    
    public bool canSeePlayer;
    public bool _detectPlayer = false;

    //attacking 
    public GameObject weapon;
    public float approachRange;
    public bool playerInAttackRange;

    private Animator animator;

    private void Awake()
    {
        health = GetComponent<Health>();
        StartCoroutine(FOVRoutine());

        player = GameObject.Find("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, approachRange, whatIsPlayer);

        //check if player is detected
        CheckHealth();
        if (canSeePlayer)
            DetectPlayer();

        if (!_detectPlayer && patrols)
            Patrolling();
        if ((_detectPlayer && !playerInAttackRange) || (_detectPlayer && playerInAttackRange && !canSeePlayer))
            Chase();
        if (_detectPlayer && playerInAttackRange)
            AttackPlayer();
        if (_detectPlayer && !canSeePlayer && !playerInAttackRange)
            Patrolling();
    }
    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FOVCheck();
        }

    }
    void FOVCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, detectionRadius, whatIsPlayer);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < detectionFOV / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, whatIsGround))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
    private void Patrolling()
    {
        if (!walkPointSet)
            SearchWalkPoint(walkPointRange);

        if (walkPointSet && !navAgent.hasPath)
            navAgent.SetDestination(walkPoint);

        Debug.DrawLine(gameObject.transform.position, walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint(float walkRange)
    {
        float randomz = Random.Range(-walkRange, walkRange);
        float randomx = Random.Range(-walkRange, walkRange);

        NavMeshPath navMeshPath = new NavMeshPath();

        walkPoint = new Vector3(transform.position.x + randomx, gameObject.transform.position.y ,  transform.position.z + randomz);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround) && navAgent.CalculatePath(walkPoint, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
        {
            walkPointSet = true;
        }
    }
    private void Chase()
    {
        navAgent.SetDestination(player.position);
        if (canSeePlayer)
            Attack();
    }
    private void AttackPlayer()
    {
        Strafe();
        transform.LookAt(player);
        if(canSeePlayer)
            Attack();
       
    }
    private void Strafe()
    {
        if (!walkPointSet)
            SearchWalkPoint(approachRange);

        if (walkPointSet && !navAgent.hasPath)
            navAgent.SetDestination(walkPoint);

        Debug.DrawLine(gameObject.transform.position, walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    
    void Attack()
    {
        transform.LookAt(player);

        if (weapon.GetComponent<ProjectileGun>().enabled == true)
        {
            weapon.GetComponent<ProjectileGun>().ReceiveInput();
        }
        else if (weapon.GetComponent<HitscanGun>().enabled == true)
        {
            weapon.GetComponent<HitscanGun>().ReceiveInput();
        }
    }
    void DetectPlayer()
    {
        _detectPlayer = true;
        
        if (hasAlerted == false)
            Alert();
    }
    void Alert()
    {
        hasAlerted = true;
        Collider[] targets = Physics.OverlapSphere(transform.position, detectionRadius);
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].GetComponent<AIMovement>())
            {
                targets[i].GetComponent<AIMovement>().DetectPlayer();
            }
        }

    }
    void CheckHealth()
    {
        if (health._currentHealth != health.maxHealth && !_detectPlayer && playerInAttackRange)        
            DetectPlayer();      
        
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }


}
