using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PoopCollector : MonoBehaviour
{
    public int score = 0; // Počítadlo hovínek
    public TextMeshProUGUI scoreText; // Připojí UI text


    void Start()
    {
        UpdateScoreText(); // Nastaví počáteční text
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("poop")) // Když hráč narazí na hovínko
        {
            Destroy(collision.gameObject); // Zničí hovínko
            score += 1; // Přičte bod
            Debug.Log("Hovínka: " + score); // Vypíše skóre do konzole
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("poop")) // Když hráč narazí na hovínko
        {
            Destroy(other.gameObject); // Zničí hovínko
            score += 1; // Přičte bod
            UpdateScoreText(); // Aktualizuje text
            Debug.Log("💩 Hovínko sebráno! Skóre: " + score); // Vypíše do konzole
        }
    }


    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Hovínka: " + score; // Aktualizace UI textu
        }
        else
        {
            Debug.LogError("⚠️ CHYBA: scoreText není přiřazen v Inspectoru!");
        }
    }

    void Update()
    {
        scoreText.text = "Hovínka: " + score;
    }

}
