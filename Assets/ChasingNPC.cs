using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingNPC : MonoBehaviour
{
    public Transform player; // Hráč
    public float speed = 50f; // Rychlost pohybu
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.UlozitSkore(); // Uložit skóre před přechodem na Game Over
            }

            SceneManager.LoadScene("GameOver");
        }
    }

}