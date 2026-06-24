using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody enemyRB;
    private GameObject player;
    public float enemySpeed;
     void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

     void Update()
    {
        Vector3 direction = (player.transform.position - gameObject.transform.position).normalized;
        enemyRB.AddForce(direction*enemySpeed*Time.deltaTime);

        // Destory On OOBs
        if (transform.position.y < -10.0)
        {
            Destroy(gameObject);
        }
    }
}
