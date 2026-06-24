using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;
    public GameObject powerup;

    public float spawnRange;

    public int enemies;

    public int wave = 1;
     void Start()
    {
        SpawnEnemy(wave);
        Instantiate(powerup, GenerateSpawnPoints(), powerup.transform.rotation);
    }

     void Update()
    {
        enemies = FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;
        if (enemies == 0){
            wave ++; 
            SpawnEnemy(wave);
            Instantiate(powerup, GenerateSpawnPoints(), powerup.transform.rotation);
        }
        
    }

    void SpawnEnemy(int enemyCount)
    {
        for (int i=0; i < enemyCount; i++)
        {
            // Add Enemy
            Instantiate(enemy, GenerateSpawnPoints(), enemy.transform.rotation);
        }       
    }

    private Vector3 GenerateSpawnPoints()
    {
        // Obtain Random Spawn Locations within Platform Range
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);

        return spawnPos;
    }
}
