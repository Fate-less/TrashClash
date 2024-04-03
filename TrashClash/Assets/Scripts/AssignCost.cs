using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;

public class AssignCost : MonoBehaviour
{
    private CurrencyCost currCost;
    private TrashCard trashCard;
    void Start()
    {
        currCost = gameObject.GetComponent<CurrencyCost>();
        trashCard = gameObject.GetComponent<TrashCard>();
        currCost.Cost[0].Cost.Amount = trashCard.Cost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
