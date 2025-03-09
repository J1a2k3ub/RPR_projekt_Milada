using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource menuMusic;

    void Start()
    {
        if (menuMusic != null && !menuMusic.isPlaying)
        {
            menuMusic.Play();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene") 
        {
            menuMusic.Stop();
        }
    }
}
