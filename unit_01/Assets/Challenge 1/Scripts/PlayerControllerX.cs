using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    // Declare Variables
    public float speed;
    public float rotationSpeed;
    public InputAction verticalAction;
    private Vector2 verticalInput;

    void Start()
    {
        verticalAction.Enable();
    }

    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = verticalAction.ReadValue<Vector2>();

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * verticalInput);
    }
}
