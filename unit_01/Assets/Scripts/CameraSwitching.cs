using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitching : MonoBehaviour
{

    [SerializeField] private InputAction cameraSwitch;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera secondCam;

    private int switchCount = 0;

     void Start()
    {
        cameraSwitch.Enable();
        mainCam.enabled = true;
        secondCam.enabled = false;
    }

     void Update()
    {
        if (cameraSwitch.triggered)
        {
            switchCount++;

            if (switchCount % 2 == 0)
            {
                mainCam.enabled = true;
                secondCam.enabled = false;
            } 
            else
            {
                mainCam.enabled = false;
                secondCam.enabled = true;
            }
        }
    }
}
