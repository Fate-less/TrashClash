using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;

public class ForceFlip : MonoBehaviour
{
    private SplayLayout cardLayout;
    private CardGroup cardGroup;
    // Start is called before the first frame update
    void Start()
    {
        cardLayout = gameObject.GetComponent<SplayLayout>();
        cardGroup = gameObject.GetComponent<CardGroup>();
    }

    public void FlipCard()
    {
        List<CardHouse.Card> cards = cardGroup.MountedCards;
        if(cardLayout.ForcedFacing == CardFacing.FaceUp)
        {
            cardLayout.ForcedFacing = CardFacing.FaceDown;
        }
        else if (cardLayout.ForcedFacing == CardFacing.FaceDown)
        { 
            cardLayout.ForcedFacing = CardFacing.FaceUp; 
        }
        for (var i = 0; i < cards.Count; i++)
        {
            var card = cards[i];
            var flipSpeed = 1f;
            cards[i].SetFacing(cardLayout.ForcedFacing, immediate: false, spd: flipSpeed);
        }
    }
}
