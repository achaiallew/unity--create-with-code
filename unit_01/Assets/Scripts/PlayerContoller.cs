using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    // Declare Variables
    public float speed = 10;
    public float turnSpeed = 3;
    public InputAction moveAction;
    public Vector2 moveInput;

    void Start()
    {
        // Enable Movement Actions
        moveAction.Enable();
    }

    void Update()
    {
        // Read Movement Input
        moveInput = moveAction.ReadValue<Vector2>();
        // Move Player Forward
        transform.Translate(Vector3.forward*Time.deltaTime*speed*moveInput.y);
        transform.Rotate(Vector3.up*Time.deltaTime*turnSpeed*moveInput.x);
    }
}
