using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionHandler : MonoBehaviour
{
    public GameObject[] cards;

    public GameObject lastSelected { get; set; }
    public int lastIndex;

    private void OnEnable()
    {
        StartCoroutine(OneFrameDelay());
    }

    IEnumerator OneFrameDelay()
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(cards[0]);
    }
    private void Update()
    {
        if (InputManager.instance.navigationInput.x > 0)
        {
            HandleCardSelection(1);
        }
        if (InputManager.instance.navigationInput.x < 0)
        {
            HandleCardSelection(-1);
        }
    }

    void HandleCardSelection(int addition)
    {
        if(EventSystem.current.currentSelectedGameObject == null && lastSelected != null)
        {
            int newIndex = lastIndex + addition;
            newIndex = Mathf.Clamp(newIndex, 0, cards.Length - 1);
            EventSystem.current.SetSelectedGameObject(cards[newIndex]);
        }
    }
}
