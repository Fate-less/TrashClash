using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[AddComponentMenu("Collection/Card")]
[System.Serializable]
public class Card : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IPointerUpHandler, IDragHandler
{
    #region Stats
    [Foldout("Card Stats")] public string title;
    [Foldout("Card Stats")] public int attack;
    [Foldout("Card Stats")] public int defense;
    [Tooltip("Untuk sekarang lebih ke deskripsi sih, " +
             "future use buat jelasin ability kalo bakal ada")]
    [Foldout("Card Stats")] public string ability;
    #endregion Stats

    #region DragDrop
    private Vector3 offset;
    public bool isDragging = false;
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector3 originalPos;
    #endregion DragDrop

    //buat sekarang useless, future use buat nanti klo ada ability
    //yang ngubah stat kartu lainnya
    public Card(string title, int attack, int defense, string ability)
    {
        this.title = title;
        this.attack = attack;
        this.defense = defense;
        this.ability = ability;
    }
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPos = rectTransform.position;
    }

    void ResetPosition()
    {
        rectTransform.position = originalPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        offset = rectTransform.position - GetPointerWorldPosition(eventData);
        isDragging = true;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Mouse Clicked");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        canvasGroup.blocksRaycasts = true;
        ResetPosition();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            rectTransform.position = GetPointerWorldPosition(eventData) + offset;
        }
    }
    private Vector3 GetPointerWorldPosition(PointerEventData eventData)
    {
        Vector3 mousePosition = eventData.position;
        Vector3 worldPosition;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, mousePosition, canvas.worldCamera, out worldPosition);
        return worldPosition;
    }


}