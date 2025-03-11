using UnityEngine;

public class ChasingNPC : MonoBehaviour
{
    public Transform player; // Hráč
    public float speed = 4f; // Rychlost pohybu
    private Rigidbody2D rb; // Rigidbody pro pohyb

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Získáme Rigidbody2D komponentu
    }

    void Update()
    {
        // Sleduj hráče - NPC se pohybuje směrem k hráči
        Vector2 direction = (player.position - transform.position).normalized;  // Vypočítáme směr
        Vector2 targetPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;

        // Pohybujeme NPC směrem k hráči pomocí MovePosition
        rb.MovePosition(targetPosition); // Move NPC do nové pozice
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pokud NPC narazí na hráče
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            // Restart hry
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
}