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
        int alt = 1;
        // Obstacle Spawns
        for (int i = 0;  i < obstacleSpawn.Count -1; i++)
        {
            Instantiate(obstacles[Random.Range(0, obstacles.Count)], obstacleSpawn[i].transform.position, Quaternion.identity);
            alt *= -1;
            Vector3 carSpawn = new Vector3(alt*xSpawn, 0, obstacleSpawn[i].transform.position.z + 12.5f);

            Instantiate(carTypes[Random.Range(0, carTypes.Count)], carSpawn, new Quaternion(0, 180, 0, 0));
        }

    }
}
