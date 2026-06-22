using UnityEngine;
using UnityEngine.InputSystem;

public class SpinPropeller : MonoBehaviour
{
    // Declare Variables
    public float spinSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3 (0, 0, spinSpeed));
    }
}
