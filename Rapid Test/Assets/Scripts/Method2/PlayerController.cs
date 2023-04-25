using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The speed at which the player moves
    public float moveSpeed = 5f;

    // The Rigidbody component of the player
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component of the player
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get the horizontal and vertical axis input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a movement vector based on the input and the moveSpeed
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed;

        // Transform the movement vector to be relative to the camera
        movement = Camera.main.transform.TransformDirection(movement);

        // Set the y component of the movement vector to 0 to prevent vertical movement
        movement.y = 0f;

        // Apply the movement vector to the Rigidbody
        rb.velocity = movement;
    }
}