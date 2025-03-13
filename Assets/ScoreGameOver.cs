using TMPro;
using UnityEngine;

public class ScoreGameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // P�ipoj UI text v Game Over sc�n�

    void Start()
    {
        int finalniSkore = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Score: " + finalniSkore;
        Debug.Log(" GameOver Score: " + finalniSkore);
    }
}
