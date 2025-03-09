using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Rychlost pohybu
    public float jumpForce = 5f; // Síla skoku
    private Rigidbody2D rb;
    private int groundContacts = 0; // Počítadlo kontaktů se zemí/objektem

    public Text coinText; // UI Text pro počet mincí
    private int coinCount = 0; // Počet nasbíraných hovínek
    public Audio_manager audioManager; // Přímé propojení s Audio_managerem (nastavit v Inspectoru!)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Pokud není Audio_manager nastaven ručně, zkusíme ho vyhledat jinak:
        if (audioManager == null)
        {
            GameObject audioObject = GameObject.Find("Audio Manager"); // Hledání podle názvu GameObjectu
            if (audioObject != null)
            {
                audioManager = audioObject.GetComponent<Audio_manager>();
            }
        }

        // Inicializace počtu hovínek
        coinText.text = "Poops: " + coinCount.ToString();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && groundContacts > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            if (audioManager != null && audioManager.Skok != null)
            {
                audioManager.PlayEfekty(audioManager.Skok);
            }
            else
            {
                Debug.LogWarning("Audio_manager nebo zvuk skoku není přiřazen!");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        groundContacts++;

        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            coinText.text = "Poops: " + coinCount.ToString();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContacts--;
        }
    }
}
