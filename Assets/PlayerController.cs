using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Rychlost pohybu
    public float jumpForce = 5f; // Síla skoku
    private Rigidbody2D rb;
    private bool isGrounded = false; // Hráč stojí na pevném povrchu

    public Text coinText; // UI Text pro počet mincí
    private int coinCount = 0; // Počet nasbíraných hovínek
    public Audio_manager audioManager; // Přímé propojení s Audio_managerem (nastavit v Inspectoru!)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (audioManager == null)
        {
            GameObject audioObject = GameObject.Find("Audio Manager");
            if (audioObject != null)
            {
                audioManager = audioObject.GetComponent<Audio_manager>();
            }
        }

        coinText.text = "Poops: " + coinCount.ToString();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; // Hráč už není na zemi

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
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                Debug.Log("Přistání na: " + collision.gameObject.name);
                break;
            }
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            coinText.text = "Poops: " + coinCount.ToString();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = false;
                Debug.Log("Opustil: " + collision.gameObject.name);
                break;
            }
        }
    }
}
