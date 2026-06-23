using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Array for Dogs
    public GameObject[] dogs;

    // Spawn Position Variables
    public float spawnRangeX;
    public float spawnZ;

    // Spawn Timing Variables
    private float delay = 2.0f;
    private float interval = 1.5f;
    
     void Start()
    {   
        InvokeRepeating("SpawnDog", delay, interval);       
    }

    void SpawnDog()
    {
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX); 
        GameObject dog = dogs[Random.Range(0, dogs.Length)];
        Instantiate(dog, new Vector3(spawnX, 0, spawnZ), dog.transform.rotation); 

    }
}
