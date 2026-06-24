using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Link to Input System
    private InputSystem_Actions controls;
    public float rotateSpeed = 10;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        controls.Enable();
    }


    void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float hInput = moveInput.x; // Right/left (A/D or arrows)
        transform.Rotate(Vector3.up, hInput* rotateSpeed* Time.deltaTime);
    }
}
