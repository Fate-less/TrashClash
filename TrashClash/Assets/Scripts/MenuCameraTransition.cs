using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraTransition : MonoBehaviour
{
    public Camera cam;
    private Vector3 startPos;

    private void Start()
    {
        startPos = cam.transform.position;
    }
    public void OpenSettings()
    {
        LeanTween.moveLocal(cam.gameObject, new Vector3(13.2186f, 50, 14.04654f), 0.5f).setEaseOutQuart();
    }

    public void BackToMain()
    {
        LeanTween.moveLocal(cam.gameObject, new Vector3(13.2186f, 9.156084f, 14.04654f), 0.5f).setEaseInQuart();
    }

    public void OpenLevelSelect()
    {
        LeanTween.moveLocal(cam.gameObject, new Vector3(-34, 9, 14), 0.5f).setEaseOutQuart();
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
