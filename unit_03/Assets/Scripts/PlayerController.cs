using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Player Rigidbody
    private Rigidbody playerRB;

    // Control Jump Action
    public InputAction jumpAction;
    // Modify Force of Jump
    public float jumpForce = 10;
    // Modify Gravity
    public float gravityModifier = 1; // cannot be 0

    // Ground Detection (prevent double jumps)
    public bool grounded = true;

    //Game Over Detection
    public bool gameOver = false;

    // Obtain Player Animator Component
    private Animator playerAnim;

    // Add Particle Effects
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    // Add Sound Effects
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerSound;


     void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        jumpAction.Enable(); 
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerSound = GetComponent<AudioSource>();
    }

     void Update()
    {
        if (jumpAction.triggered == true && grounded && !gameOver)
        {
            playerRB.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            grounded = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerSound.PlayOneShot(jumpSound, 1.0f);           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver){
            grounded = true;
            dirtParticle.Play();
        } 
        else if (collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            Debug.Log("GameOver");
            explosionParticle.Play();
            dirtParticle.Stop();
            playerSound.PlayOneShot(crashSound, 1.0f); 
            if (collision.transform.position.x > gameObject.transform.position.x)
            {
                //gameObject.transform.rotation = new Quaternion(0, 90, 0, 90);
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
            }
            else
            {
                //gameObject.transform.rotation = new Quaternion(0, 90, 0, 90);
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 2);
            }
            
        }
        
    }
}
