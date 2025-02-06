using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab; // Prefab země
    public Transform player; // Hráč
    public float groundWidth = 10f; // Šířka jednoho segmentu země
    private float nextSpawnX = 0f;

    public GameObject chasingNPC; // Nepřítel (ChasingNPC), který honí hráče
    public float speed = 5f; // Rychlost pohybu hráče

    private void Start()
    {
        // Na začátku vygenerujeme několik segmentů, aby hráč nespadl
        for (int i = 0; i < 5; i++)
        {
            SpawnGround();
        }


    }

    private void Update()
    {
        // Pokud se hráč blíží k dalšímu místu pro generování, přidáme zem
        if (player.position.x > nextSpawnX - groundWidth)
        {
            SpawnGround();
        }

        // Pohyb hlavní postavy
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        player.Translate(new Vector2(moveX, moveY) * speed * Time.deltaTime);
    }

    void SpawnGround()
    {
        // Vytvoření segmentu na správné pozici
        Instantiate(groundPrefab, new Vector2(nextSpawnX, -3), Quaternion.identity);

        // Posuneme pozici pro další segment
        nextSpawnX += groundWidth; // Posuneme X pozici pro nový segment
    }

    

}


public class GameOverTrigger : MonoBehaviour
{
    // Funkce, která se spustí při kolizi
    private void OnCollisionEnter(Collision collision)
    {
        // Zkontrolujeme, zda koliduje hráč
        if (collision.gameObject.CompareTag("Player")) // Ujisti se, že máš tag "Player" na hráči
        {
            // Vypneme hru
            Application.Quit();

            // Pokud testuješ hru v editoru Unity, použij následující řádek, aby se hra zastavila
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
