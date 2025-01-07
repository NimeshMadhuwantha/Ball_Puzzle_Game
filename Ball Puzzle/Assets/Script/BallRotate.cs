using UnityEngine;

public class BallRotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the ball around the z-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}

