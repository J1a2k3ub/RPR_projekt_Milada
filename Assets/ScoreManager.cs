using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    private Transform player;

    private float startX;
    private int aktualniSkore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Znovu na��st UI a hr��e po zm�n� sc�ny
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        NajdiUI();
        NajdiHrace();
        ResetovatSkore();
    }

    private void Update()
    {
        if (player == null)
        {
            NajdiHrace();
            return;
        }

        int noveSkore = Mathf.FloorToInt(player.position.x - startX);
        if (noveSkore > aktualniSkore)
        {
            aktualniSkore = noveSkore;
            AktualizovatUI();
        }
    }

    public void NajdiHrace()
    {
        player = GameObject.FindWithTag("Player")?.transform;
        if (player != null)
        {
            startX = player.position.x;
        }
        else
        {
            Debug.LogWarning(" ScoreManager: Hr�� nebyl nalezen! Po�k�me a zkus�me znovu.");
            Invoke("NajdiHrace", 0.5f); // Po�kejme 0.5 sekundy a zkus�me to znovu
        }
    }

    private void NajdiUI()
    {
        scoreText = GameObject.Find("Skore")?.GetComponent<TextMeshProUGUI>();

        if (scoreText == null)
        {
            Debug.LogWarning(" ScoreManager: UI text pro sk�re nebyl nalezen! Po�k�me a zkus�me znovu.");
            Invoke("NajdiUI", 0.5f); // Po�kejme 0.5 sekundy a zkus�me to znovu
        }
    }

    public void ResetovatSkore()
    {
        aktualniSkore = 0;
        AktualizovatUI();
    }

    public void UlozitSkore()
    {
        PlayerPrefs.SetInt("Score", aktualniSkore);
        PlayerPrefs.Save();
    }

    private void AktualizovatUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + aktualniSkore;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(" Sc�na zm�n�na: " + scene.name);
        NajdiUI();
        NajdiHrace();
        ResetovatSkore();
    }
}
