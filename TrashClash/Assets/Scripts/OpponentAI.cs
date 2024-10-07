using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;

public class OpponentAI : MonoBehaviour
{
    public CardGroup handCard;
    public RandomLocation location;
    public PhaseManager phaseManager;
    public GameObject area1;
    public GameObject area2;
    public GameObject area3;

    //Same location
    public TrashCard SearchBestCard()
    {
        TrashCard bestCard = handCard.MountedCards[0].GetComponent<TrashCard>();
        for (int i = 1; i < handCard.MountedCards.Count; i++)
        {
            TrashCard currentCard = handCard.MountedCards[i].GetComponent<TrashCard>();
            if (location.firstLocation.ToString() == currentCard.Kategori.ToString() || location.secondLocation.ToString() == currentCard.Kategori.ToString() || location.thirdLocation.ToString() == currentCard.Kategori.ToString())
            {
                if(currentCard.Value > bestCard.Value)
                {
                    bestCard = currentCard;
                }
            }
        }
        return bestCard;
    }

    //Highest power
    public TrashCard SearchSecondBestCard()
    {
        TrashCard bestCard = handCard.MountedCards[0].GetComponent<TrashCard>();
        for (int i = 1; i < handCard.MountedCards.Count; i++)
        {
            TrashCard currentCard = handCard.MountedCards[i].GetComponent<TrashCard>();
            if (currentCard.None > bestCard.None)
            {
                bestCard = currentCard;
            }
        }
        return bestCard;
    }

    public void PlaceBestCard()
    {
        TrashCard card = SearchBestCard();
        if(card.Kategori.ToString() == location.firstLocation.ToString())
        {
            bool cardPlaced = false;
            for(int i = 0;i < 3; i++)
            {
                if (area1.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count == 0)
                {
                    CardHouse.Card baseCard = card.gameObject.GetComponent<CardHouse.Card>();
                    area1.transform.GetChild(i).GetComponent<CardGroup>().Mount(baseCard);
                    cardPlaced = true;
                    break;
                }
            }
            if (!cardPlaced)
            {
                PlaceSecondBestCard();
            }
        }
        else if(card.Kategori.ToString() == location.secondLocation.ToString())
        {
            bool cardPlaced = false;
            for (int i = 0; i < 3; i++)
            {
                if (area2.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count == 0)
                {
                    CardHouse.Card baseCard = card.gameObject.GetComponent<CardHouse.Card>();
                    area2.transform.GetChild(i).GetComponent<CardGroup>().Mount(baseCard);
                    cardPlaced = true;
                    break;
                }
            }
            if (!cardPlaced)
            {
                PlaceSecondBestCard();
            }
        }
        else if (card.Kategori.ToString() == location.thirdLocation.ToString())
        {
            bool cardPlaced = false;
            for (int i = 0; i < 3; i++)
            {
                if (area3.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count == 0)
                {
                    CardHouse.Card baseCard = card.gameObject.GetComponent<CardHouse.Card>();
                    area3.transform.GetChild(i).GetComponent<CardGroup>().Mount(baseCard);
                    cardPlaced = true;
                    break;
                }
            }
            if (!cardPlaced)
            {
                PlaceSecondBestCard();
            }
        }
        else
        {
            PlaceSecondBestCard();
        }
    }

    public void PlaceSecondBestCard()
    {
        TrashCard card = SearchSecondBestCard();
        bool cardPlaced = false;
        for (int i = 0; i < 3; i++)
        {
            if (area1.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count == 0)
            {
                CardHouse.Card baseCard = card.gameObject.GetComponent<CardHouse.Card>();
                area1.transform.GetChild(i).GetComponent<CardGroup>().Mount(baseCard);
                cardPlaced = true;
                break;
            }
        }
        if (!cardPlaced)
        {
            for (int i = 0; i < 3; i++)
            {
                if (area2.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count == 0)
                {
                    CardHouse.Card baseCard = card.gameObject.GetComponent<CardHouse.Card>();
                    area2.transform.GetChild(i).GetComponent<CardGroup>().Mount(baseCard);
                    cardPlaced = true;
                    break;
                }
            }
        }
        if (!cardPlaced)
        {
            for (int i = 0; i < 3; i++)
            {
                if (area3.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count == 0)
                {
                    CardHouse.Card baseCard = card.gameObject.GetComponent<CardHouse.Card>();
                    area3.transform.GetChild(i).GetComponent<CardGroup>().Mount(baseCard);
                    cardPlaced = true;
                    break;
                }
            }
        }
    }

    public void AITurn()
    {
        StartCoroutine(delayedMove());
    }

    IEnumerator delayedMove()
    {
        yield return new WaitForSeconds(1f);
        PlaceBestCard();
        yield return new WaitForSeconds(0.5f);
        phaseManager.NextPhase();
    }
}
