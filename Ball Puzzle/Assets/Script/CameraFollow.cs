using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public Vector3 offset; // Offset from the player position

    void Start()
    {
        // Initialize the offset and adjust the zoom by reducing the z value
        offset = transform.position - player.transform.position;
        offset.z += 8.0f; // Zoom in closer by default (reduce distance)
    }

    void LateUpdate()
    {
        // Follow the player with the adjusted offset
        transform.position = player.transform.position + offset;
    }
}


