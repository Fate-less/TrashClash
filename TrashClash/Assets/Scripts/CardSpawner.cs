using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public Transform firstTrans;
    public Transform lastTrans;
    public SelectionHandler selectHandler;
    public Transform worldCanvasTrans;

    // Start is called before the first frame update
    void Start()
    {
        selectHandler = GetComponent<SelectionHandler>();
        DisplayCard();
    }

    public void DisplayCard()
    {
        float space = (lastTrans.position.x - firstTrans.position.x) / (selectHandler.cards.Length - 1);
        for(int i = 0; i < selectHandler.cards.Length; i++)
        {
            GameObject newCard = Instantiate(selectHandler.cards[i], new Vector2(firstTrans.position.x + space * i, firstTrans.position.y), Quaternion.identity);
            newCard.transform.SetParent(worldCanvasTrans);
        }
    }
}
