using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab; // Prefab zemì
    public Transform player; // Hráè
    public float groundWidth = 10f; // Šíøka jednoho segmentu zemì
    private float nextSpawnX = 0f;

    private void Start()
    {
        // Na zaèátku vygenerujeme nìkolik segmentù, aby hráè nespadl
        for (int i = 0; i < 5; i++)
        {
            SpawnGround();
        }
    }

    private void Update()
    {
        // Pokud se hráè blíží k dalšímu místu pro generování, pøidáme zem
        if (player.position.x > nextSpawnX - groundWidth)
        {
            SpawnGround();
        }
    }

    void SpawnGround()
    {
        // Vytvoøení segmentu na správné pozici
        Instantiate(groundPrefab, new Vector2(nextSpawnX, -3), Quaternion.identity);

        // Posuneme pozici pro další segment
        nextSpawnX += groundWidth; // Posuneme X pozici pro nový segment
    }
}
