using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawns enemies on start
        spawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //returns the count of enemies onto the screen
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            spawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
    void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //spawn new enemies
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        //Spawns decided by where on the board based on their X or Z positions
        float spawnPosX = Random.Range(spawnRange, spawnRange);
        float spawnPosZ = Random.Range(spawnRange, spawnRange);
        //Creates a random spawn based on the above numbers
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        
        return randomPos;
    }
}
