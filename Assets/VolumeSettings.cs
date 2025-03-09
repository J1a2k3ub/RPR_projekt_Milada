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
        // Naètení uložených hodnot nebo výchozí nastavení
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 1f);

        // Aplikování hlasitosti na AudioSource
        musicSource.volume = musicSlider.value;
        effectsSource.volume = effectsSlider.value;

        // Pøidání listeneru pro zmìnu hodnoty
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