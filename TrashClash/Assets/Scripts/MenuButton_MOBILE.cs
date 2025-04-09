using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuButton_MOBILE : MonoBehaviour
{
    [Header("Materials")]
    public Material BGM_UNMUTE_MATERIAL;
    public Material BGM_MUTE_MATERIAL;
    public Material SFX_UNMUTE_MATERIAL;
    public Material SFX_MUTE_MATERIAL;
    public Material CHECKLIST_ON;
    public Material CHECKLIST_OFF;
    [Header("Reference")]
    public GameObject playButtonObj;
    public GameObject bgmButtonObj;
    public GameObject sfxButtonObj;
    public GameObject languageButtonObj;
    public GameObject languagePopup;
    public GameObject languagePopupCheckBindo;
    public GameObject languagePopupCheckEnglish;
    public GameObject confirmExitPopup;

    private string selectedLanguage = "English";

    private AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if(audioManager.sfxIsMuted) sfxButtonObj.GetComponent<MeshRenderer>().material = SFX_MUTE_MATERIAL;
        else sfxButtonObj.GetComponent<MeshRenderer>().material = SFX_UNMUTE_MATERIAL;
        if (audioManager.bgmIsMuted) bgmButtonObj.GetComponent<MeshRenderer>().material = BGM_MUTE_MATERIAL;
        else bgmButtonObj.GetComponent<MeshRenderer>().material = BGM_UNMUTE_MATERIAL;
        UpdateLanguageChecklist();
    }
    public void PlayButton()
    {
        string sceneName = selectedLanguage == "English" ? "SingleplayerEN_MOBILE" : "Singleplayer_MOBILE";
        SceneManager.LoadScene(sceneName);
    }
    public void MuteBGM()
    {
        if (audioManager.bgmIsMuted)
        {
            audioManager.bgmIsMuted = false;
            bgmButtonObj.GetComponent<MeshRenderer>().material = BGM_UNMUTE_MATERIAL;
        }
        else
        {
            audioManager.bgmIsMuted = true;
            bgmButtonObj.GetComponent<MeshRenderer>().material = BGM_MUTE_MATERIAL;
        }
    }
    public void MuteSFX()
    {
        if (audioManager.sfxIsMuted)
        {
            audioManager.sfxIsMuted = false;
            sfxButtonObj.GetComponent<MeshRenderer>().material = SFX_UNMUTE_MATERIAL;
        }
        else
        {
            audioManager.sfxIsMuted = true;
            sfxButtonObj.GetComponent<MeshRenderer>().material = SFX_MUTE_MATERIAL;
        }
    }
    public void LanguagePopup()
    {
        languagePopup.SetActive(true);
        playButtonObj.SetActive(false);
        bgmButtonObj.SetActive(false);
        sfxButtonObj.SetActive(false);
        languageButtonObj.SetActive(false);
    }
    public void ExitPopup()
    {
        if (confirmExitPopup.activeInHierarchy)
        {
            Application.Quit();
        }
        confirmExitPopup.SetActive(true);
        playButtonObj.SetActive(false);
        bgmButtonObj.SetActive(false);
        sfxButtonObj.SetActive(false);
        languageButtonObj.SetActive(false);
    }

    public void UpdateLanguageChecklist()
    {
        if (selectedLanguage == "English")
        {
            languagePopupCheckEnglish.GetComponent<MeshRenderer>().material = CHECKLIST_ON;
            languagePopupCheckBindo.GetComponent<MeshRenderer>().material = CHECKLIST_OFF;
        }
        else
        {
            languagePopupCheckEnglish.GetComponent<MeshRenderer>().material = CHECKLIST_OFF;
            languagePopupCheckBindo.GetComponent<MeshRenderer>().material = CHECKLIST_ON;
        }
    }

    public void ChangeLanguageToBINDO()
    {
        selectedLanguage = "Bahasa Indoonesia";
        UpdateLanguageChecklist();
    }
    public void ChangeLanguageToEnglish()
    {
        selectedLanguage = "English";
        UpdateLanguageChecklist();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (confirmExitPopup.activeInHierarchy)
            {
                confirmExitPopup.SetActive(false);
                playButtonObj.SetActive(true);
                bgmButtonObj.SetActive(true);
                sfxButtonObj.SetActive(true);
                languageButtonObj.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (languagePopup.activeInHierarchy)
            {
                languagePopup.SetActive(false);
                playButtonObj.SetActive(true);
                bgmButtonObj.SetActive(true);
                sfxButtonObj.SetActive(true);
                languageButtonObj.SetActive(true);
            }
            else ExitPopup();
        }
    }
}
