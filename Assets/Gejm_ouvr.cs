using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gejm_ouvr : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Text pro sk�re na Game Over panelu

    public void ShowGameOver()
    {
        // Zkontroluj, zda m�me ulo�en� sk�re a zobraz je
        if (PlayerPrefs.HasKey("Score"))
        {
            int score = PlayerPrefs.GetInt("Score");
            scoreText.text = "Score: " + score.ToString(); // Nastav� text na sk�re
        }
        else
        {
            scoreText.text = "Score: 0"; // Pokud ��dn� sk�re nen�, zobraz� 0
        }
    }

    public void Restart()
    {
        // Restartov�n� hry
        SceneManager.LoadScene("SampleScene");
    }

    public void Home()
    {
        // Vr�t� zp�t na hlavn� menu
        SceneManager.LoadScene("Main Menu");
    }
}
