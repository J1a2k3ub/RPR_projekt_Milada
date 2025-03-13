using UnityEngine;
using TMPro; // Pro zobrazení skóre

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText; // Pøipoj UI text v Unity
    public Transform player; // Pøipoj hráèe v Unity

    private float startX; // Poèáteèní pozice hráèe
    private int aktualniSkore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Uchová skóre i po zmìnì scény
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
            startX = player.position.x; // Uložíme startovní pozici
        }
        else
        {
            Debug.LogError(" ScoreManager: Hráè není pøiøazen! Pøipoj hráèe v Inspectoru.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            int noveSkore = Mathf.FloorToInt(player.position.x - startX); // Skóre podle vzdálenosti
            if (noveSkore > aktualniSkore) // Zvýšíme skóre jen pokud hráè dojde dál
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
        Debug.Log(" Skóre bylo uloženo: " + aktualniSkore);
    }

    private void AktualizovatUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + aktualniSkore;
        }
    }
}
