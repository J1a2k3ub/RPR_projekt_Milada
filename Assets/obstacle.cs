using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Pole pro v�ce prefab�
    public float spawnIntervalInFrames = 8f;
    public float startX = 6f;
    public float spawnYMin = -4f;
    public float spawnYMax = 0f;
    public float minXIncrease = 1200;
    public float maxXIncrease = 10000;

    private float lastX;
    private int frameCount;
    private int lastObstacleIndex = -1; // Uchov�me index posledn� p�ek�ky

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
        // N�hodn� v�b�r prefab�, kter� se neshoduje s posledn� p�ek�kou
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, obstaclePrefabs.Length);
        } while (randomIndex == lastObstacleIndex); // Dokud se nevybere jin� ne� posledn�

        GameObject selectedPrefab = obstaclePrefabs[randomIndex];

        // Generov�n� pozice p�ek�ky
        float randomXIncrease = Random.Range(minXIncrease, maxXIncrease);
        float spawnX = lastX + randomXIncrease;
        float spawnY = Random.Range(spawnYMin, spawnYMax);

        // Debugging pro ov��en� hodnot
        Debug.Log($"Spawned obstacle at X: {spawnX}, Y: {spawnY}");

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, -1f);
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        lastX = spawnX;
        lastObstacleIndex = randomIndex; // Ulo��me index posledn� p�ek�ky
    }
}
