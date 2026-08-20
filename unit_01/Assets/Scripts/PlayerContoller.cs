using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    // Declare Car Variables
    public float speed = 20;
    public float turnSpeed = 30;
    [SerializeField] private InputAction moveAction;
    [SerializeField] private Vector2 moveInput;

    public bool activeContols = true;
    public bool winGame = false;

    void Start()
    {
        // Enable Input Actions
        moveAction.Enable();
        activeContols = true;
        winGame = false;
    }

    void FixedUpdate()
    {
        // Read Movement Input
        moveInput = moveAction.ReadValue<Vector2>();

        // Move Player Forward
        if (activeContols != false)
        {
            transform.Translate(Vector3.forward*Time.deltaTime*speed*moveInput.y);
            transform.Rotate(Vector3.up*Time.deltaTime*turnSpeed*moveInput.x);
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Finish")
        {
            winGame = true;
        }
    }


}
