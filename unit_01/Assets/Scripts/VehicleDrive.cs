using Unity.VisualScripting;
using UnityEngine;

public class VehicleDrive : MonoBehaviour
{

    public float speed;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           gameManager.gameState = false;
        }
        
    }


}
