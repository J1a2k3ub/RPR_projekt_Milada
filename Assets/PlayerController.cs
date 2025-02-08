using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Rychlost pohybu
    public float jumpForce = 7f; // S�la skoku
    private Rigidbody2D rb;
    private bool isGrounded;

    private int coinCount = 0;

    private Text coinText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
        // Pohyb doprava a doleva �ipkami
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // Skok (? �ipka nebo mezern�k)
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            // Zvýšíme počet mincí
            coinCount++;
            // Aktualizujeme text UI pro minci
            if (coinText != null)
            {
                coinText.text = "poops: " + coinCount.ToString();
            }

            // Zničíme minci, jakmile ji hráč sebere
            Destroy(collision.gameObject);
        }

        // Detekce kontaktu se zemí
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("poop"))
        {
            // Zvýšíme počet mincí
            coinCount++;
            // Aktualizujeme text UI pro minci
            coinText.text = "poops: " + coinCount.ToString();

            // Zničíme minci, jakmile ji hráč sebere
            Destroy(collision.gameObject);
        }

        // Detekce kontaktu se zemí
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


}


public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f; // Síla skoku
    private Rigidbody rb;
    private bool isGrounded; // Zjistí, jestli je hráč na zemi

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Najde Rigidbody hráče


    }

    void Update()
    {
        // Skok po stisku mezerníku a pokud je hráč na zemi
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Zabrání dvojitému skoku
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Když se hráč dotkne země, nastavíme isGrounded na true
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}




