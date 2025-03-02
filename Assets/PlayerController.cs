using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Rychlost pohybu
    public float jumpForce = 7f; // Síla skoku
    private Rigidbody2D rb;
    private bool isGrounded;

    private int coinCount = 0;

    private Text coinText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Hledáme UI text pro počet mincí
        GameObject coinTextObject = GameObject.FindGameObjectWithTag("poop1");

        if (coinTextObject != null)
        {
            coinText = coinTextObject.GetComponent<Text>();
        }
        else
        {
            Debug.LogError("Text with tag 'poop1' not found!");
        }
    }

    void Update()
    {
        // Pohyb doprava a doleva pomocí šipek
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y); // Používáme rb.velocity místo linearVelocity

        // Skok pokud je hráč na zemi
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Skákání - změna pouze Y komponenty
            isGrounded = false; // Nastavíme, že hráč není na zemi, dokud nedopadne
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Pokud je kontakt se zemí, je hráč na zemi
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            // Zvýšení počtu mincí
            coinCount++;
            if (coinText != null)
            {
                coinText.text = "poops: " + coinCount.ToString(); // Aktualizace UI textu
            }

            Destroy(collision.gameObject); // Zničení mince po sebrání
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Pokud hráč opustí zem, není na ní
        }
    }
}
