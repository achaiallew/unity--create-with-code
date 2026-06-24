using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Spawn Obstacle
    // public GameObject[] obstacles;
    public GameObject obstacle;

    // Repeat Spawn
    public float delay = 0;
    public float rate = 2;

    // Spawn Position
    private float spawnX = 30;

    // Reference Player Controller 
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();   
        InvokeRepeating("SpawnObstacles", delay, rate);
    }


    void SpawnObstacles()
    {
        if (playerController.gameOver != true)
        {
            //GameObject obstacle = obstacles[Random.Range(0, 1)];
            Vector3 spawnPos = new Vector3(spawnX, obstacle.transform.position.y, obstacle.transform.position.z);
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);      
        }
        
        
    }
}
