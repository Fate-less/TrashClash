using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public TMP_Dropdown languageDropdown;
    public Button singleplayerButton;
    public Button multiplayerButton;

    private string selectedLanguage;

    private void Start()
    {
        try
        {
            languageDropdown.ClearOptions();
            List<string> options = new List<string> { "Bahasa Indonesia", "English" };
            languageDropdown.AddOptions(options);
            languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
            volumeSlider.onValueChanged.AddListener(SetVolume);
            volumeSlider.value = AudioListener.volume;
            singleplayerButton.onClick.AddListener(OnSingleplayerButtonClicked);
            multiplayerButton.onClick.AddListener(OnMultiplayerButtonClicked);

            LoadSettings();
        }
        catch { }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    private void OnLanguageChanged(int index)
    {
        selectedLanguage = index == 0 ? "Bahasa Indonesia" : "English";
        PlayerPrefs.SetString("SelectedLanguage", selectedLanguage);
    }

    private void OnSingleplayerButtonClicked()
    {
        string sceneName = selectedLanguage == "English" ? "SingleplayerEN" : "Singleplayer";
        SceneManager.LoadScene(sceneName);
    }
    private void OnMultiplayerButtonClicked()
    {
        string sceneName = selectedLanguage == "English" ? "MultiplayerOfflineEN" : "MultiplayerOffline";
        SceneManager.LoadScene(sceneName);
    }

    private void LoadSettings()
    {
        selectedLanguage = PlayerPrefs.GetString("SelectedLanguage", "English");
        int index = selectedLanguage == "Bahasa Indonesia" ? 0 : 1;
        languageDropdown.value = index;
    }
}
