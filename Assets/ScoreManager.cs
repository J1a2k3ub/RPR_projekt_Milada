using UnityEngine;
using TMPro; // Pro zobrazen� sk�re

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText; // P�ipoj UI text v Unity
    public Transform player; // P�ipoj hr��e v Unity

    private float startX; // Po��te�n� pozice hr��e
    private int aktualniSkore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Uchov� sk�re i po zm�n� sc�ny
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (player != null)
        {
            startX = player.position.x; // Ulo��me startovn� pozici
        }
        else
        {
            Debug.LogError(" ScoreManager: Hr�� nen� p�i�azen! P�ipoj hr��e v Inspectoru.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            int noveSkore = Mathf.FloorToInt(player.position.x - startX); // Sk�re podle vzd�lenosti
            if (noveSkore > aktualniSkore) // Zv���me sk�re jen pokud hr�� dojde d�l
            {
                aktualniSkore = noveSkore;
                AktualizovatUI();
            }
        }
    }

    public void UlozitSkore()
    {
        PlayerPrefs.SetInt("Score", aktualniSkore);
        PlayerPrefs.Save();
        Debug.Log(" Sk�re bylo ulo�eno: " + aktualniSkore);
    }

    private void AktualizovatUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + aktualniSkore;
        }
    }
}
