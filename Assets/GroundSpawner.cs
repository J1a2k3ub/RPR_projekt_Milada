using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab; // Prefab zem�
    public Transform player; // Hr��
    public float groundWidth = 10f; // ���ka jednoho segmentu zem�
    private float nextSpawnX = 0f;

    private void Start()
    {
        // Na za��tku vygenerujeme n�kolik segment�, aby hr�� nespadl
        for (int i = 0; i < 5; i++)
        {
            SpawnGround();
        }
    }

    private void Update()
    {
        // Pokud se hr�� bl�� k dal��mu m�stu pro generov�n�, p�id�me zem
        if (player.position.x > nextSpawnX - groundWidth)
        {
            SpawnGround();
        }
    }

    void SpawnGround()
    {
        // Vytvo�en� segmentu na spr�vn� pozici
        Instantiate(groundPrefab, new Vector2(nextSpawnX, -3), Quaternion.identity);

        // Posuneme pozici pro dal�� segment
        nextSpawnX += groundWidth; // Posuneme X pozici pro nov� segment
    }
}
