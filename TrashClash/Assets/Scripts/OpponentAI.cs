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


    public void ReadSituation()
    {
        int totalPlacedCardArea1 = 0;
        int totalPlacedCardArea2 = 0;
        int totalPlacedCardArea3 = 0;
        for (int i = 0; i < 4; i++)
        {
            if (area1.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count > 0)
            {
                totalPlacedCardArea1++;
            }
            if (area2.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count > 0)
            {
                totalPlacedCardArea2++;
            }
            if (area3.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count > 0)
            {
                totalPlacedCardArea3++;
            }
        }
        if (totalPlacedCardArea1 > 2 || totalPlacedCardArea2 > 2 || totalPlacedCardArea3 > 2)
        {
            if(area1.GetComponent<PowerCounter>().allyCounter[0].power / 3 >
                area1.GetComponent<PowerCounter>().enemyCounter[0].power || 
                area2.GetComponent<PowerCounter>().allyCounter[1].power / 3 >
                area2.GetComponent<PowerCounter>().enemyCounter[1].power || 
                area3.GetComponent<PowerCounter>().allyCounter[2].power / 3 >
                area3.GetComponent<PowerCounter>().enemyCounter[2].power)
            {
                PlaceSecondBestCard();
            }
            else
            {
                PlaceBestCard();
            }
        }
        else
        {
            PlaceBestCard();
        }
    }
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
            for(int i = 0;i < 4; i++)
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
            for (int i = 0; i < 4; i++)
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
            for (int i = 0; i < 4; i++)
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
        int randArea = Random.Range(1, 3);
        if(randArea == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                if (area1.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count == 0)
                {
                    CardHouse.Card baseCard = card.gameObject.GetComponent<CardHouse.Card>();
                    area1.transform.GetChild(i).GetComponent<CardGroup>().Mount(baseCard);
                    cardPlaced = true;
                    break;
                }
            }
        }
        else if(randArea == 2)
        {
            for (int i = 0; i < 4; i++)
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
        else if(randArea == 3)
        {
            for (int i = 0; i < 4; i++)
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
        if (!cardPlaced)
        {
            for (int i = 0; i < 4; i++)
            {
                if (area1.transform.GetChild(i).GetComponent<CardGroup>().MountedCards.Count == 0)
                {
                    CardHouse.Card baseCard = card.gameObject.GetComponent<CardHouse.Card>();
                    area1.transform.GetChild(i).GetComponent<CardGroup>().Mount(baseCard);
                    cardPlaced = true;
                    break;
                }
            }
        }
        if (!cardPlaced)
        {
            for (int i = 0; i < 4; i++)
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
            for (int i = 0; i < 4; i++)
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
        ReadSituation();
        yield return new WaitForSeconds(0.5f);
        phaseManager.NextPhase();
    }
}
