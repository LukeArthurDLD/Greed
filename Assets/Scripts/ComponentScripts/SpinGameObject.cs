using UnityEngine;

public class SpinGameObject : MonoBehaviour
{
    [Header("Spin About Axis")]
    public bool x = false;
    public bool y = false;
    public bool z = false;

    [Header("Rotational Velocity")]
    public float spinSpeedX = 1f;
    public float spinSpeedY = 1f;
    public float spinSpeedZ = 1f;

    // Float - Angle Rotation
    float rotateX;
    float rotateY;
    float rotateZ;

    void Start()
    {
        // Set - Initial Position of Game Object
        SetInitialPosition();

        // Set - Rotation Speed
        SetRotationVelocity();
    }

    void Update()
    {
        // Spin - Game Object
        Spin();
    }

    void SetInitialPosition()
    {
        // Rotate - Game Object
        this.transform.Rotate(0, 0, 0, Space.Self);
    }

    void SetRotationVelocity()
    {
        // Check - If X is True
        if (x == true)
        {
            // Set - Rotation Speed about X Axis
            rotateX = Time.deltaTime * spinSpeedX; 
        }

        // Check - If Y is True
        if (y == true)
        {
            // Set - Rotation Speed about Y Axis
            rotateY = Time.deltaTime * spinSpeedY;
        }

        // Check - If Z is True
        if (z == true)
        {
            // Set - Rotation Speed about Z Axis
            rotateZ = Time.deltaTime * spinSpeedZ;
        }
    }

    void Spin()
    {
        // Rotate - Game Object
        this.transform.Rotate(rotateX, rotateY, rotateZ, Space.Self);
    }
}
