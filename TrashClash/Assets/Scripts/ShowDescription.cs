using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CardHouse;

public class ShowDescription : MonoBehaviour
{
    private Image cardImage;
    private TextMeshProUGUI descTMP;

    // Start is called before the first frame update
    void Start()
    {
        cardImage = GameObject.FindWithTag("Card Image").GetComponent<Image>();
        descTMP = GameObject.FindWithTag("Card Desc").GetComponent<TextMeshProUGUI>();
    }

    public void ShowCardDesc()
    {
        cardImage.sprite = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite;
        descTMP.text = GetComponent<TrashCard>().Description;
    }
}
