using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameBackButton : MonoBehaviour
{
    private MenuButton_MOBILE menuButtonScript;

    private void Start()
    {
        menuButtonScript = GameObject.Find("Handler").GetComponent<MenuButton_MOBILE>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Singleplayer_MOBILE" || SceneManager.GetActiveScene().name == "SingleplayerEN_MOBILE")
                SceneManager.LoadScene("Mainmenu_MOBILE");
            else
                menuButtonScript.ExitPopup();
        }
    }
}
