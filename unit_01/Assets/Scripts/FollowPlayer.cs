using UnityEngine;
using UnityEngine.InputSystem;

public class FollowPlayer : MonoBehaviour
{
    // Declare Variables
    public GameObject player;
    [SerializeField]private Vector3 offsetTP = new Vector3(0, 5, -8);
    [SerializeField]private Vector3 offsetFP = new Vector3(0, 2, 0.9f);

    // Camera Switch Variables
    [SerializeField] private InputAction cameraSwitch;
    private int switchCount = 0;

    void Start()
    {
        cameraSwitch.Enable();
    }

    void LateUpdate() {
        //transform.position = player.transform.position + offsetTP;

        // Check for Camera Switching
        if (cameraSwitch.triggered)
        {
            switchCount++;
        }


        if (switchCount % 2 == 0)
        {
            // Third Person Camera
            transform.position = player.transform.position + offsetTP;
        } 
        else
        {
            // First Person Camera
            transform.position = player.transform.position + offsetFP;
        }

    }
}
