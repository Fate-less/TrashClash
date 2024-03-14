using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public void Battle(Card playerCard, Card enemyCard)
    {
        // Example battle mechanic based on attack and defense
        int playerDamage = playerCard.attack - enemyCard.defense;
        int enemyDamage = enemyCard.attack - playerCard.defense;

        if (playerDamage > 0)
        {
            // Player card wins or deals damage
        }

        if (enemyDamage > 0)
        {
            // Enemy card wins or deals damage
        }

        // Implement outcome (e.g., card destroyed, player health reduced)
    }
}

