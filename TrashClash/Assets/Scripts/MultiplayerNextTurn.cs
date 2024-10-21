using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerNextTurn : MonoBehaviour
{
    public GameObject nextTurnButtonP1;
    public GameObject nextTurnButtonP2;
    
    public void HideButtonP1()
    {
        StartCoroutine(delayHideButtonP1());
    }

    public void HideButtonP2()
    {
        StartCoroutine(delayHideButtonP2());
    }

    IEnumerator delayHideButtonP1()
    {
        yield return new WaitForSeconds(0.3f);
        nextTurnButtonP1.SetActive(false);
        nextTurnButtonP2.SetActive(true);
    }
    IEnumerator delayHideButtonP2()
    {
        yield return new WaitForSeconds(0.3f);
        nextTurnButtonP2.SetActive(false);
        nextTurnButtonP2.SetActive(true);
    }
}
