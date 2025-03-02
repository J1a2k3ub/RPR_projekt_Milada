using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab překážky
    public float spawnIntervalInFrames = 8f; // Generování každých 5 snímků (můžeš nastavit podle potřeby)
    public float startX = 6f; // Počáteční X pozice první překážky
    public float spawnYMin = -4f; // Minimální Y pozice
    public float spawnYMax = 0f; // Maximální Y pozice
    public float minXIncrease = 1200; // Minimální posun doprava
    public float maxXIncrease = 10000; // Maximální posun doprava

    private float lastX; // Poslední X pozice
    private int frameCount; // Počet snímků

    void Start()
    {
        lastX = startX; // Nastavíme počáteční pozici
        frameCount = 0;
    }

    void Update()
    {
        frameCount++;

        if (frameCount >= spawnIntervalInFrames) // Pokud uplynul počet snímků
        {
            SpawnObstacle();
            frameCount = 0; // Resetujeme počet snímků
        }
    }

    void SpawnObstacle()
    {
        // Zajistíme, že nové překážky budou vždy větší než předchozí
        float randomXIncrease = Random.Range(minXIncrease, maxXIncrease); // Náhodný posun doprava
        float spawnX = lastX + randomXIncrease; // Nová X pozice (vždy více doprava)
        float spawnY = Random.Range(spawnYMin, spawnYMax); // Náhodná Y pozice

        // Debugging pro ověření hodnot
        Debug.Log($"Spawned obstacle at X: {spawnX}, Y: {spawnY}");

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, -1f);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        lastX = spawnX; // Uložíme novou X pozici pro další překážku
    }
}
