using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[AddComponentMenu("Collection/Card")]
[System.Serializable]
public class Card : MonoBehaviour
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
    private bool isDragging = false;
    private Rigidbody rb;
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
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        originalPos = transform.position;
    }
    private void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }
    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            newPosition.z = 9;
            rb.MovePosition(newPosition);
        }
    }
    private void OnMouseUp()
    {
        isDragging = false;
        ResetPosition();
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    void ResetPosition()
    {
        transform.position = originalPos;
    }
}

