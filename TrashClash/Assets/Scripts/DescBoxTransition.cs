using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescBoxTransition : MonoBehaviour
{
    public GameObject descriptionTab;
    public Transform closePosition;
    public Transform openPosition;
    public bool isOnCooldown;

    private void Start()
    {
        //if(!Application.isMobilePlatform)
        //{
        //    StartCoroutine(delayOneFrame());
        //}
    }

    public void ShowCardDescBox()
    {
        if (!isOnCooldown)
        {
            LeanTween.move(descriptionTab, openPosition.position, 0.1f);
            descriptionTab.SetActive(true);
        }
    }
    public void CloseCardDescBox()
    {
        if (!isOnCooldown)
        {
            LeanTween.move(descriptionTab, closePosition.position, 0.1f);
            descriptionTab.SetActive(false);
        }
    }

    IEnumerator delayOneFrame()
    {
        if (!isOnCooldown)
        {
            yield return new WaitForSeconds(0.1f);
            descriptionTab.SetActive(false);
            CloseCardDescBox();
        }
    }

    public void PutCooldown(int duration)
    {
        isOnCooldown = true;
        StartCoroutine(CooldownTimer(duration));
    }

    IEnumerator CooldownTimer(int duration)
    {
        yield return new WaitForSeconds(duration);
        isOnCooldown = false;
    }

    public void MobileShowDescription()
    {
        if (!isOnCooldown)
        {
            descriptionTab.transform.position = openPosition.position;
        }
    }

    public void MobileCloseCardDescBox()
    {
        if (!isOnCooldown)
        {
            descriptionTab.transform.position = closePosition.position;
        }
    }
}
