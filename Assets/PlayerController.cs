using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f; // Rychlost pohybu
    public float jumpForce = 10f; // Síla skoku
    private Rigidbody2D rb;
    private bool isGrounded = false; // Určuje, zda je postava na pevném povrchu

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
    }

    void Update()
    {
        // Pohyb postavy
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y); // Používáme velocity místo linearVelocity

        // Skok, pokud je postava na zemi nebo na překážce (tag "Ground" nebo "Obstacle")
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Skok na ose Y

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

    // Detekce kontaktu s objektem (zemí nebo překážkou)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Pokud je postava v kontaktu s objektem, který má tag "Ground" nebo "Obstacle"
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = true; // Pokud je postava na zemi nebo překážce, umožníme skákání
        }
    }

    // Detekce ukončení kontaktu s objektem
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Pokud postava přestane být na zemi nebo překážce, skákání není možné
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = false;
        }
    }

    // Generování země
    public GameObject groundPrefab; // Prefab pro generování nové země
    public Transform player; // Odkaz na postavu, abychom věděli, kde generovat novou zem

    void GenerateGround()
    {
        // Předpokládáme, že generování je 5 jednotek vpravo od postavy
        Vector3 spawnPosition = player.transform.position + new Vector3(5, 0, 0); // Generuje objekty 5 jednotek vpravo od hráče

        // Vytvoříme nový objekt pro zem
        GameObject newGround = Instantiate(groundPrefab, spawnPosition, Quaternion.identity);
        newGround.tag = "Ground"; // Ujisti se, že má správný tag
        newGround.AddComponent<BoxCollider2D>(); // Pokud nemá Collider, přidej ho
    }
}
