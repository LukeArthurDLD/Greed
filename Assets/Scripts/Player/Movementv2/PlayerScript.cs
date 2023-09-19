 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class PlayerScript : MonoBehaviour
{
    public GameObject spawnpoint;
    // Start is called before the first frame update
    private Rigidbody rb;
    private Health health;
   
    //movement
    public float moveSpeed = 2500;
    public float moveSpeedModifier = 1f; //keep as one
    private float _baseModifier;
    public float maxSpeed = 20;
    private bool _alwaysGo = false;
    public bool grounded;
    public Vector3 groundNormal;
    public LayerMask whatIsGround;
    public float counterMovement = 0.175f;
    private float threshold = 0.01f;
    public float maxSlopeAngle = 35f;
    public float resetpoint;

    //crouch and sliding
    private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale;
    public float slideForce = 400;
    public float slideCounterMovement = 0.2f;
    private Vector3 normalvector = Vector3.up;
    private Vector3 wallNormalVector;
    
    public float crouchHeight;
    private float runningHeight;
    private float capsuleHeight;    

    //jumping
    private bool readytojump = true;
    private float jumpCoolDown = 0.25f;
    public float jumpForce = 550f;

    //input
    float x, y;
    bool jumping, sprinting, crouching;     //test to see if they can be put on different lines
    private float desiredX;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        SetSpeed(moveSpeedModifier);

        health = GetComponent<Health>();
        playerScale = transform.localScale;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.position = spawnpoint.transform.position;
        rb.velocity = Vector3.zero;


        //setHeights
        runningHeight = GetComponent<CapsuleCollider>().height;
        capsuleHeight = runningHeight;
        
    }
    private void FixedUpdate()
    {
        Movement();

    }

    private void Update()
    {

        //reads input
        MyInput();
        //checks life
        OutOfMap();
        CheckHP();
        //Stairs();
        GetComponent<CapsuleCollider>().height = capsuleHeight;

    }
    //movement classes
    private void MyInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        jumping = Input.GetButton("Jump");
        crouching = Input.GetButton("Crouch");
        if (_alwaysGo)
            y = 1;
        if (Input.GetButtonDown("Crouch"))
            StartCrouch();
        if (Input.GetButtonUp("Crouch"))
            StopCrouch();
    }
    private void StartCrouch()
    {

        capsuleHeight = crouchHeight;
        //transform.localScale = crouchScale;

        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        if(rb.velocity.magnitude > 0.5f)
        {
            if(grounded)
            {
                rb.AddForce(transform.forward * slideForce);
            }
        }
    }
    private void Stairs()
    {
        if(grounded)
        {
            this.rb.useGravity = false;
        }
        else
        {
            this.rb.useGravity = true;
        }
    }
    
    private void StopCrouch()
    {
        capsuleHeight = runningHeight;

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }

    private void Movement()
    {             

        //extra gravity
        rb.AddForce(Vector3.down * Time.deltaTime * 10);

        //finds velocity relative to where player is looking
        Vector2 mag = FindVelRelToLook();
        float xmag = mag.x, ymag = mag.y;

        //counteract sliding and sloppy movement
        CounterMovement(x, y, mag);

        //if holding  jump && ready to jump , then jump
        if (readytojump && jumping) 
            Jump();



        //sets max speed
        float maxspeed = this.maxSpeed;

        


        if (crouching && grounded && readytojump)
        {
            rb.AddForce(Vector3.down * Time.deltaTime * 3000);
            return;
        }

        //if speed is larger than maxspeed, cancel out the input so you dont go over max speed
        if (x > 0 && xmag > (maxspeed * moveSpeedModifier)) x = 0;
        if (x < 0 && xmag < (-maxspeed * moveSpeedModifier)) x = 0;
        if (y > 0 && ymag > (maxspeed * moveSpeedModifier)) y = 0;
        if (y < 0 && ymag < (-maxspeed * moveSpeedModifier)) y = 0;

        float multiplier = 1f;
        float multiplierV = 1f;

        //movement in the air
        if(!grounded)
        {
            multiplier = 0.5f;
            multiplierV = 0.5f;
        }

        //movement while sliding 
        if (grounded && crouching) multiplierV = 0f;

        Vector3 groundForward = Vector3.ProjectOnPlane(transform.forward, groundNormal).normalized;
        Vector3 groundRight = Vector3.ProjectOnPlane(transform.right, groundNormal).normalized;

        //Apply forces to move player
        rb.AddForce(groundForward * y * (moveSpeed *moveSpeedModifier) * Time.deltaTime * multiplier * multiplierV);
        rb.AddForce(groundRight * x * (moveSpeed * moveSpeedModifier) * Time.deltaTime * multiplier);
    }
    private void Jump()
    {
        if (grounded && readytojump)
        {
            readytojump = false;

            //add jump forces
            rb.AddForce(Vector2.up * jumpForce * 1.5f);
            rb.AddForce(normalvector * jumpForce * 0.5f);

            //if jumping while falling, reset y velocity

            Vector3 vel = rb.velocity;
            if (rb.velocity.y < 0.5f)
            {
                rb.velocity = new Vector3(vel.x, 0, vel.z);
            }
            else if (rb.velocity.y > 0)
                rb.velocity = new Vector3(vel.x, vel.y / 2, vel.z);
            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }
    private void ResetJump()
    {
        readytojump = true;
    }

   
    private void CounterMovement(float x, float y, Vector2 mag)
    {
        if (!grounded || jumping) return;

        //slow down sliding
        if(crouching)
        {
            rb.AddForce(moveSpeed * Time.deltaTime * -rb.velocity.normalized * slideCounterMovement);
            return;
        }
        
        //counter movement (when not holding any keys will try to stop all velocity
        if (Math.Abs(mag.x) > threshold && Math.Abs(x) < 0.05f || (mag.x < -threshold && x > 0) || (mag.x > threshold && x < 0))
        {
            rb.AddForce(moveSpeed * transform.right * Time.deltaTime * -mag.x * counterMovement);
        }
        if (Math.Abs(mag.y) > threshold && Math.Abs(y) < 0.05f || (mag.y < -threshold && y > 0) || (mag.y > threshold && y < 0))
        {
            rb.AddForce(moveSpeed * transform.forward * Time.deltaTime * -mag.y * counterMovement);
        }
        
        if (Mathf.Sqrt((Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2))) > maxSpeed)
        {
            float fallspeed = rb.velocity.y;
            Vector3 n = rb.velocity.normalized * maxSpeed;
            rb.velocity = new Vector3(n.x, fallspeed, n.z);
        }
    }
    public void SetSpeed(float stat)
    {
        _baseModifier = stat;
        moveSpeedModifier = stat;
    }
    public void ModifySpeed(float modifier)
    {
        //modifier
        moveSpeedModifier += modifier;
    }
    public void ResetModifier()
    {
        moveSpeedModifier = _baseModifier;
    }
    public Vector2 FindVelRelToLook()
    {
        float lookAngle = transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitue = rb.velocity.magnitude;
        float xmag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);
        float ymag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);

        return new Vector2(xmag, ymag);
    }

    private bool IsFloor(Vector3 v)
    {
        float angle = Vector3.Angle(Vector3.up, v);
        return angle < maxSlopeAngle;
    }

    private bool cancellingGrounded;

    private void OnCollisionStay(Collision other)
    {
        int layer = other.gameObject.layer;
        if (whatIsGround != (whatIsGround | (1 << layer))) return;

        for (int i = 0; i < other.contactCount; i++)
        {
            Vector3 normal = other.contacts[i].normal;
            //floor
            if(IsFloor(normal))
            {
                grounded = true;
                groundNormal = normal;

                cancellingGrounded = false;
                normalvector = normal;
                CancelInvoke(nameof(StopGrounded));
            }
        }
        float delay = 3f;
        if(!cancellingGrounded)
        {
            cancellingGrounded = true;
            Invoke(nameof(StopGrounded), Time.deltaTime * delay );
        }
    }
    private void StopGrounded()
    {
        grounded = false;
        groundNormal = Vector3.up;
    }
    private void OutOfMap()
    {

        if (transform.position.y < resetpoint)
        {
            OnDeath();
            
        }
    }
    void CheckHP()
    {
        if (health._currentHealth <= 0)
            OnDeath();
    }
    void OnDeath()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(0);
    }
    public void AlwaysForward(bool isActive)
    {
        _alwaysGo = isActive;
    }
    
}
