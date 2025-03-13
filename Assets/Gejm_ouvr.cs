using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gejm_ouvr : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void Restart()
    {
        // Reset sk�re p�ed restartem
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetovatSkore();
        }

        SceneManager.LoadScene("SampleScene");
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
