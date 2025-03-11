using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int aktualniSkore = 0; // Skóre hráèe

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ZvysitSkore(int hodnota)
    {
        aktualniSkore += hodnota;
    }

    public void UlozitSkore()
    {
        PlayerPrefs.SetInt("Score", aktualniSkore);
        PlayerPrefs.Save();
    }

    public int ZiskejSkore()
    {
        return aktualniSkore;
    }
}
