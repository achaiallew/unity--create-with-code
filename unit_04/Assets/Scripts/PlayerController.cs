using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Link to Input System
    private InputSystem_Actions controls;
    public float playerSpeed = 10;
    private Rigidbody playerRB;

    private GameObject focalPoint;

    public bool powerup = false;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;

    void Awake()
    {
        controls = new InputSystem_Actions();
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    void OnEnable()
    {
        controls.Enable();
    }


    void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float fInput = moveInput.y; // Forward (W or arrows)
        playerRB.AddForce(focalPoint.transform.forward * fInput* playerSpeed* Time.deltaTime);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            powerup = true;
            powerupIndicator.SetActive(true);

            // Start Coroutine
            StartCoroutine(PowerUpRoutine());
        }
    }

    IEnumerator PowerUpRoutine()
    {
        yield return new WaitForSeconds(7);
        powerup = false;
        powerupIndicator.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && powerup)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 direction =  (collision.gameObject.transform.position - gameObject.transform.position).normalized;

            // Send Enemy Away
            enemyRB.AddForce(direction*powerupStrength, ForceMode.Impulse);

        }

    }

}

