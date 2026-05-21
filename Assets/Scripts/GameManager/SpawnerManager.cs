using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;
    [SerializeField] private GameObject crabPrefab;
    [SerializeField] private GameObject pufferfishPrefab;
    [SerializeField] private GameObject minePrefab;

    [SerializeField] private int initialFishCount = 20;
    [SerializeField] private int initialCrabCount = 5;
    [SerializeField] private int initialPufferfishCount = 3;
    [SerializeField] private int initialMineCount = 4;

    [SerializeField] private Vector3 spawnAreaMin = new Vector3(-50, -30, -50);
    [SerializeField] private Vector3 spawnAreaMax = new Vector3(50, 10, 50);

    [SerializeField] private float respawnTime = 2f;

    private float respawnTimer = 0f;

    private void Start()
    {
        SpawnInitialEnemies();
    }

    private void Update()
    {
        respawnTimer -= Time.deltaTime;
        if (respawnTimer <= 0)
        {
            RespawnEnemies();
            respawnTimer = respawnTime;
        }
    }

    private void SpawnInitialEnemies()
    {
        for (int i = 0; i < initialFishCount; i++)
            SpawnFish();

        for (int i = 0; i < initialCrabCount; i++)
            SpawnCrab();

        for (int i = 0; i < initialPufferfishCount; i++)
            SpawnPufferfish();

        for (int i = 0; i < initialMineCount; i++)
            SpawnMine();
    }

    private void RespawnEnemies()
    {
        int currentFish = GameObject.FindGameObjectsWithTag("Fish").Length;
        int currentCrabs = GameObject.FindGameObjectsWithTag("Crab").Length;
        int currentPufferfish = GameObject.FindGameObjectsWithTag("Pufferfish").Length;
        int currentMines = GameObject.FindGameObjectsWithTag("Mine").Length;

        if (currentFish < initialFishCount)
            SpawnFish();
        if (currentCrabs < initialCrabCount)
            SpawnCrab();
        if (currentPufferfish < initialPufferfishCount)
            SpawnPufferfish();
        if (currentMines < initialMineCount)
            SpawnMine();
    }

    private void SpawnFish()
    {
        Vector3 spawnPos = GetRandomSpawnPosition();
        Instantiate(fishPrefab, spawnPos, Quaternion.identity);
    }

    private void SpawnCrab()
    {
        Vector3 spawnPos = GetRandomSpawnPosition();
        Instantiate(crabPrefab, spawnPos, Quaternion.identity);
    }

    private void SpawnPufferfish()
    {
        Vector3 spawnPos = GetRandomSpawnPosition();
        Instantiate(pufferfishPrefab, spawnPos, Quaternion.identity);
    }

    private void SpawnMine()
    {
        Vector3 spawnPos = GetRandomSpawnPosition();
        Instantiate(minePrefab, spawnPos, Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );
    }
}
