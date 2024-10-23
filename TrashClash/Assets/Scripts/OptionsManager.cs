using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider; // Slider for volume control
    public TMP_Dropdown languageDropdown; // Dropdown for language selection
    public Button singleplayerButton;
    public Button multiplayerButton;

    private string selectedLanguage;

    private void Start()
    {
        try
        {
            // Set up the language dropdown
            languageDropdown.ClearOptions();
            List<string> options = new List<string> { "Bahasa Indonesia", "English" };
            languageDropdown.AddOptions(options);
            languageDropdown.onValueChanged.AddListener(OnLanguageChanged);

            // Set up the volume slider
            volumeSlider.onValueChanged.AddListener(SetVolume);

            // Set initial volume
            volumeSlider.value = AudioListener.volume;

            // Set up the play button listener
            singleplayerButton.onClick.AddListener(OnSingleplayerButtonClicked);
            multiplayerButton.onClick.AddListener(OnMultiplayerButtonClicked);

            // Load saved settings if any
            LoadSettings();
        }
        catch { }
    }

    // Method to change the AudioListener volume
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    // Method called when language is changed
    private void OnLanguageChanged(int index)
    {
        selectedLanguage = index == 0 ? "Bahasa Indonesia" : "English";
        // Save the selected language if needed
        PlayerPrefs.SetString("SelectedLanguage", selectedLanguage);
    }

    // Method called when the play button is clicked
    private void OnSingleplayerButtonClicked()
    {
        // Load the game scene based on selected language
        string sceneName = selectedLanguage == "English" ? "SingleplayerEN" : "Singleplayer";
        SceneManager.LoadScene(sceneName);
    }
    private void OnMultiplayerButtonClicked()
    {
        // Load the game scene based on selected language
        string sceneName = selectedLanguage == "English" ? "MultiplayerOfflineEN" : "MultiplayerOffline";
        SceneManager.LoadScene(sceneName);
    }

    // Method to load saved settings
    private void LoadSettings()
    {
        selectedLanguage = PlayerPrefs.GetString("SelectedLanguage", "English");
        int index = selectedLanguage == "Bahasa Indonesia" ? 0 : 1;
        languageDropdown.value = index;
    }
}
