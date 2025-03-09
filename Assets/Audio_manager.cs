using UnityEngine;

public class Audio_manager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource; // Hudba na pozadí
    [SerializeField] private AudioSource SFXSource;   // Zvukové efekty

    public AudioClip pozadi;  // Hudba na pozadí
    public AudioClip Skok;    // Zvuk skoku

    private void Start()
    {
        if (musicSource != null && pozadi != null)
        {
            musicSource.clip = pozadi;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("❌ Chybí MusicSource nebo zvuk pozadí!");
        }
    }

    public void PlayEfekty(AudioClip zvuk)
    {
        if (SFXSource != null && zvuk != null)
        {
            SFXSource.PlayOneShot(zvuk);
        }
        else
        {
            Debug.LogWarning("❌ Chybí SFXSource nebo zvuk efektu!");
        }
    }
}
