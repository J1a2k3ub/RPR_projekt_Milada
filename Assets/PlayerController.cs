using UnityEngine;
using UnityEngine.UI; // Pro práci s UI (Text pro zobrazení počtu hovínek)

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Rychlost pohybu
    public float jumpForce = 5f; // Síla skoku
    private Rigidbody2D rb;
    private int groundContacts = 0; // Počítadlo kontaktů se zemí/objektem

    public Text coinText; // UI Text pro počet mincí
    private int coinCount = 0; // Počet nasbíraných hovínek

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Inicializace počtu hovínek
        coinText.text = "Poops: " + coinCount.ToString();
    }

    void Update()
    {
        // Pohyb doprava a doleva pomocí šipek
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // Skok, pokud je hráč v kontaktu se zemí/objektem
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && groundContacts > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Jakýkoliv kontakt znamená, že je hráč na zemi
        groundContacts++;

        // Pokud se hráč dotkne hovínka (s tagem "Coin"), přičteme bod
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCount++; // Zvyšujeme počet hovínek
            coinText.text = "Poops: " + coinCount.ToString(); // Aktualizujeme zobrazení počtu
            Destroy(collision.gameObject); // Zničíme sebrané hovínko
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Pokud opustíme objekt, snížíme počet kontaktů
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContacts--;
        }
    }
}
