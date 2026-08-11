using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> obstacles;
    public List<GameObject> obstacleSpawn;

    public List<GameObject> carTypes;
    public float xSpawn;



    void Awake() 
    {
        // Obstacle Spawns
        for (int i = 0;  i < obstacleSpawn.Count -1; i++)
        {
            Instantiate(obstacles[Random.Range(0, obstacles.Count)], obstacleSpawn[i].transform.position, Quaternion.identity);
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
