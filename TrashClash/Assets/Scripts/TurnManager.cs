using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject[] player1CardSlots; // Array of GameObjects representing player 1's card slots
    public GameObject[] player2CardSlots; // Array of GameObjects representing player 2's card slots

    private int currentPlayerTurn = 1; // Variable to keep track of current player's turn (1 for player 1, 2 for player 2)
    private int currentCardIndex = 0; // Variable to keep track of the index of the card being placed

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the game with player 1's turn
        currentPlayerTurn = 1;
        currentCardIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if it's player's turn and if there are still cards to be placed
        if (currentPlayerTurn == 1 && currentCardIndex < player1CardSlots.Length)
        {
            // Handle player 1's turn
            if (Input.GetMouseButtonDown(0)) // Assuming left mouse click is used to place the card
            {
                // Place the card in the current card slot
                // Example: player1CardSlots[currentCardIndex].PlaceCard(card);
                currentCardIndex++;

                // Check if all cards are placed by player 1
                if (currentCardIndex >= player1CardSlots.Length)
                {
                    // Switch to player 2's turn
                    currentPlayerTurn = 2;
                    currentCardIndex = 0;
                }
            }
        }
        else if (currentPlayerTurn == 2 && currentCardIndex < player2CardSlots.Length)
        {
            // Handle player 2's turn
            if (Input.GetMouseButtonDown(0)) // Assuming left mouse click is used to place the card
            {
                // Place the card in the current card slot
                // Example: player2CardSlots[currentCardIndex].PlaceCard(card);
                currentCardIndex++;

                // Check if all cards are placed by player 2
                if (currentCardIndex >= player2CardSlots.Length)
                {
                    // Switch to player 1's turn
                    currentPlayerTurn = 1;
                    currentCardIndex = 0;

                    // Now both players have placed their cards, you can proceed to the next phase of the game
                    // For example, you can trigger the start of the game logic or any other actions here
                }
            }
        }
    }
}

