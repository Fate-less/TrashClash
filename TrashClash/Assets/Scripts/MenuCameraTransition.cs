using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraTransition : MonoBehaviour
{
    [Header("Referencing")]
    public Camera cam;
    public Transform settingsPos;
    public Transform levelSelectPos;
    public Transform defaultMenuPos;
    private Vector3 startPos;

    private void Start()
    {
        startPos = cam.transform.position;
    }
    public void OpenSettings()
    {
        LeanTween.moveLocal(cam.gameObject, settingsPos.position, 0.5f).setEaseOutQuart();
    }

    public void BackToMain()
    {
        LeanTween.moveLocal(cam.gameObject, defaultMenuPos.position, 0.5f).setEaseInQuart();
    }

    public void OpenLevelSelect()
    {
        LeanTween.moveLocal(cam.gameObject, levelSelectPos.position, 0.5f).setEaseOutQuart();
    }

    //temporary
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMain();
        }
    }
}
