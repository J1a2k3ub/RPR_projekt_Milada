using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gejm_ouvr : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Text pro skóre na Game Over panelu

    public void ShowGameOver()
    {
        // Zkontroluj, zda máme uložené skóre a zobraz je
        if (PlayerPrefs.HasKey("Score"))
        {
            int score = PlayerPrefs.GetInt("Score");
            scoreText.text = "Score: " + score.ToString(); // Nastaví text na skóre
        }
        else
        {
            scoreText.text = "Score: 0"; // Pokud žádné skóre není, zobrazí 0
        }
    }

    public void Restart()
    {
        // Restartování hry
        SceneManager.LoadScene("SampleScene");
    }

    public void Home()
    {
        // Vrátí zpìt na hlavní menu
        SceneManager.LoadScene("Main Menu");
    }
}
