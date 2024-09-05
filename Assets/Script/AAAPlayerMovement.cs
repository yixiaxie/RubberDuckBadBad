using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AAAPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float mouseSensitivity = 100f; // Sensitivity of mouse look
    public float gravity = -9.81f; // Gravity for the player
    public CharacterController controller; // CharacterController component

    private Vector3 velocity; // For gravity simulation
    private float xRotation = 0f; // Rotation around the X-axis (up/down)
    private float yRotation = 0f; // Rotation around the Y-axis (left/right)

    void Start()
    {
        // Ensure the cursor is locked to the screen and hidden
        Cursor.lockState = CursorLockMode.Locked;

        // Get the CharacterController component
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Handle player movement using WASD
        HandleMovement();

        //// Handle mouse look to rotate the player
        HandleMouseLook();

        // Apply gravity
        ApplyGravity();
    }

    void HandleMovement()
    {
        // Get input from WASD or arrow keys
        float moveX = Input.GetAxis("Horizontal"); // A/D keys (left/right)
        float moveZ = Input.GetAxis("Vertical");   // W/S keys (forward/backward)

        // Calculate movement direction based on the player's current orientation
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the player using the character controller
        controller.Move(move * moveSpeed * Time.deltaTime);

        
    }

    void HandleMouseLook()
    {

        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player horizontally (Y-axis) based on mouseX
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Rotate the camera vertically (X-axis) based on mouseY (up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp to prevent flipping

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void ApplyGravity()
    {
        // Check if the player is on the ground and reset vertical velocity if so
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Slight downward force to keep the player grounded
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical velocity to the player
        controller.Move(velocity * Time.deltaTime);
    }
}
