using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescBoxTransition : MonoBehaviour
{
    public GameObject descriptionTab;
    public Transform closePosition;
    public Transform openPosition;

    private void Start()
    {
        StartCoroutine(delayOneFrame());
    }

    public void ShowCardDescBox()
    {
        LeanTween.move(descriptionTab, openPosition.position, 0.1f);
        descriptionTab.SetActive(true);
    }
    public void CloseCardDescBox()
    {
        LeanTween.move(descriptionTab, closePosition.position, 0.1f);
        descriptionTab.SetActive(false);
    }

    IEnumerator delayOneFrame()
    {
        yield return new WaitForSeconds(0.1f);
        descriptionTab.SetActive(false);
        CloseCardDescBox();
    }
}
