using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;

public class CostCheck : MonoBehaviour
{
    public CurrencyGate costGate;
    public CurrencyCost cardCost;
    public bool costActivated = false;

    private void Start()
    {
        cardCost = gameObject.GetComponent<CurrencyCost>();
        costGate = gameObject.GetComponent<CurrencyGate>();
    }

    public void CheckCard()
    {
        if (!costActivated)
        {
            cardCost.Activate();
            costGate.SetIsActive(false);
            costActivated = true;
        }
        else
        {
            cardCost.Deactivate();
            costGate.SetIsActive(true);
            costActivated = false;
        }
    }
}
