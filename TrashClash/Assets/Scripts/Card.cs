using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string name;
    public int attack;
    public int defense;
    public string ability; // Simplified, consider using more complex structures for abilities

    public Card(string name, int attack, int defense, string ability)
    {
        this.name = name;
        this.attack = attack;
        this.defense = defense;
        this.ability = ability;
    }
}

