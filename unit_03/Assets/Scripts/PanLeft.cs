using UnityEngine;

public class PanLeft : MonoBehaviour
{
    // Control Speed
    public float panSpeed = 30;
    // Bounds
    public float boundsX; 

    // Reference Player Controller Script
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.gameOver != true)
        {
            transform.Translate(Vector3.left*Time.deltaTime*panSpeed);
        }

        if (gameObject.transform.position.x <= boundsX && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }

}
