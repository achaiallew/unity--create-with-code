using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;

    private float minSpeed = 12;
    private float maxSpeed = 18;
    private float maxTorque = 5;
    private float xRange = 4;
    private float yPos = -4;

    private GameManager gameManager;

    public int points;
    public int bombCount = 0;
    public int fruitCount = 0;

    public ParticleSystem explosionParticle;


    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPosition();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

     void Update()
    {
        if (gameManager.gameActive){
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Debug.Log("Mouse Was Clicked");
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                Debug.DrawRay(ray.origin, ray. direction * 100f, Color.red, 2f);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    // If Hit, Destory
                    if (hit.transform == transform)
                    {
                        //if (gameObject.CompareTag("Bad")){  bombCount+= 1;  }
                        Destroy(gameObject);
                        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                        gameManager.UpdateScore(points);

                        //if (bombCount >= 3) {   gameManager.GameOver(); }
                    }
                }
            }
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
     Vector3 RandomPosition()
    {
       return new Vector3(Random.Range(-xRange,  xRange), yPos, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyZone")){   Destroy(gameObject);    }    

        if (!gameObject.CompareTag("Bad")){ 
            //fruitCount +=1; }

        //if (fruitCount > 5){    
        gameManager.GameOver(); }
    }
}
