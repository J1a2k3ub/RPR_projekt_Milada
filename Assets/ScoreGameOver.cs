using TMPro;
using UnityEngine;

public class ScoreGameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int finalniSkore = PlayerPrefs.GetInt("Score", 0);

        if (scoreText != null)
        {
            scoreText.text = "Score: " + finalniSkore;
        }

        Debug.Log("GameOver Score: " + finalniSkore);
    }
}
