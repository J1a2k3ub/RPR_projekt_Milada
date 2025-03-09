using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    private void Start()
    {
        // Na�ten� ulo�en�ch hodnot nebo v�choz� nastaven�
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 1f);

        // Aplikov�n� hlasitosti na AudioSource
        musicSource.volume = musicSlider.value;
        effectsSource.volume = effectsSlider.value;

        // P�id�n� listeneru pro zm�nu hodnoty
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        effectsSource.volume = volume;
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }
}