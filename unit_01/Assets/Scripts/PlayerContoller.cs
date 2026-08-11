using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    // Declare Car Variables
    public float speed = 20;
    public float turnSpeed = 30;
    [SerializeField] private InputAction moveAction;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private InputAction speedUpAction;

    void Start()
    {
        // Enable Input Actions
        moveAction.Enable();
        speedUpAction.Enable();
    }

    void FixedUpdate()
    {
        // Read Movement Input
        moveInput = moveAction.ReadValue<Vector2>();
        // Move Player Forward
        transform.Translate(Vector3.forward*Time.deltaTime*speed*moveInput.y);
        transform.Rotate(Vector3.up*Time.deltaTime*turnSpeed*moveInput.x);
    }

    

    void Update()
    {
        if (speedUpAction.IsInProgress())
        {
            speed *= 1.5f;
        }
        else
        {
            speed /= 1.5f;
        }
    }
}
