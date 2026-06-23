using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Declare Variables
    public InputAction moveAction;
    public InputAction fireAction;
    private Vector2 moveInput; 

    public float speed = 10.0f;

    public float leftEdge;
    public float rightEdge;

    public GameObject projectile;


    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    void Update()
    {
        // Keep Player in Range
        if (transform.position.x <= leftEdge)
        {
            transform.position = new Vector3(leftEdge, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= rightEdge)
        {
            transform.position = new Vector3(rightEdge, transform.position.y, transform.position.z);
        }
       
        // Obtain Movement Input
        moveInput = moveAction.ReadValue<Vector2>();
        // Move the Player
        transform.Translate(Vector3.right*Time.deltaTime*speed*moveInput.x);

        // Shoot Projectile on Fire private void OnApplicationFocus(bool focusStatus) {
        if (fireAction.triggered == true)
        {
            Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        }
        
    
    }
}
