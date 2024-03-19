using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] float verticalMove = 30f;
    [SerializeField] float transitionTime = 0.1f;
    [Range(0, 2f), SerializeField] float scaleIncrease = 1.1f;

    private Vector3 startPos;
    private Vector3 startScale;
    public SelectionHandler selectHandler;
    private Card card;

    private void Start()
    {
        startPos = transform.position;
        startScale = transform.localScale;
        selectHandler = gameObject.GetComponentInParent<SelectionHandler>();
        card = gameObject.GetComponent<Card>();
    }

    IEnumerator CardTransition(bool selected)
    {
        Vector3 endPosition;
        Vector3 endScale;

        float currentTime = 0f;
        while(currentTime < transitionTime)
        {
            currentTime += Time.deltaTime;

            if (selected)
            {
                endPosition = startPos + new Vector3(0f, verticalMove, 0f);
                endScale = startScale * scaleIncrease;
            }

            else
            {
                endPosition = startPos;
                endScale = startScale;
            }

            Vector3 lerpPos = Vector3.MoveTowards(transform.position, endPosition, (currentTime / transitionTime));
            Vector3 lerpScale = Vector3.MoveTowards(transform.localScale, endScale, (currentTime / transitionTime));

            transform.position = lerpPos;
            transform.localScale = lerpScale;

            yield return null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.selectedObject = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (!card.isDragging)
        {
            StartCoroutine(CardTransition(true));
        }
        selectHandler.lastSelected = gameObject;
        for(int i = 0; i < selectHandler.cards.Length; i++)
        {
            if(selectHandler.cards[i] == gameObject)
            {
                selectHandler.lastIndex = i;
                return;
            }
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        StartCoroutine(CardTransition(false));
    }
}
