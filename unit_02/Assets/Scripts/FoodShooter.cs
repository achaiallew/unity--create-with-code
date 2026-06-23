using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
    

public class FoodShooter : MonoBehaviour
{
    //Declare Variables
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*speed);

    }
    

}
