using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Pole pro více prefabù
    public float spawnIntervalInFrames = 8f;
    public float startX = 6f;
    public float spawnYMin = -4f;
    public float spawnYMax = 0f;
    public float minXIncrease = 1200;
    public float maxXIncrease = 10000;

    private float lastX;
    private int frameCount;
    private int lastObstacleIndex = -1; // Uchováme index poslední pøekážky

    void Start()
    {
        lastX = startX;
        frameCount = 0;
    }

    void Update()
    {
        frameCount++;

        if (frameCount >= spawnIntervalInFrames)
        {
            SpawnObstacle();
            frameCount = 0;
        }
    }

    void SpawnObstacle()
    {
        // Náhodný výbìr prefabù, který se neshoduje s poslední pøekážkou
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, obstaclePrefabs.Length);
        } while (randomIndex == lastObstacleIndex); // Dokud se nevybere jiný než poslední

        GameObject selectedPrefab = obstaclePrefabs[randomIndex];

        // Generování pozice pøekážky
        float randomXIncrease = Random.Range(minXIncrease, maxXIncrease);
        float spawnX = lastX + randomXIncrease;
        float spawnY = Random.Range(spawnYMin, spawnYMax);

        // Debugging pro ovìøení hodnot
        Debug.Log($"Spawned obstacle at X: {spawnX}, Y: {spawnY}");

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, -1f);
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        lastX = spawnX;
        lastObstacleIndex = randomIndex; // Uložíme index poslední pøekážky
    }
}
