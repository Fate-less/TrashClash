using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;
using TMPro;

public class PowerCounter : MonoBehaviour
{
    public PowerCounter[] enemyCounter;
    public PowerCounter[] allyCounter;
    public string kategoriArea;
    [SerializeField] TextMeshPro powerLabel;
    public CardGroup[] slot;
    public int power;
    public int[] powers;

    public void CountPower()
    {
        //try renew
        for (int i = 0; i < 4; i++)
        {
            try
            {
                if(slot[i].MountedCards.Count == 0)
                {
                    powers[i] = 0;
                }
                else
                {
                    if (slot[i].MountedCards[0].GetComponent<DragDetector>().IsActive)
                    {
                        Debug.Log("Recount: " + slot[i].MountedCards.Count);
                        //ngitung power for each slot
                        if (kategoriArea == slot[i].MountedCards[0].GetComponent<TrashCard>().Kategori.ToString())
                        {
                            powers[i] += slot[i].MountedCards[0].GetComponent<TrashCard>().Value;
                            //Debuff
                            enemyCounter[GetArray()].power += slot[i].MountedCards[0].GetComponent<TrashCard>().Buff;
                            //affectAlly
                            if (slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyArea &&
                                slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition == ActiveCondition.TrueCategory ||
                                slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition == ActiveCondition.BothCategory)
                            {
                                for (int j = i; j < 3; j++)
                                {
                                    if (j != GetArray())
                                    {
                                        Debug.Log(slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition);
                                        Debug.Log("affect ally same category");
                                        allyCounter[j].power += slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyAmount;
                                    }
                                }
                            }
                            //affectEnemy
                            if (slot[i].MountedCards[0].GetComponent<TrashCard>().affectEnemyArea &&
                                slot[i].MountedCards[0].GetComponent<TrashCard>().affectEnemyCondition == ActiveCondition.TrueCategory ||
                                slot[i].MountedCards[0].GetComponent<TrashCard>().affectEnemyCondition == ActiveCondition.BothCategory)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (j != GetArray())
                                    {
                                        Debug.Log("affect enemy same category");
                                        enemyCounter[j].power += slot[i].MountedCards[0].GetComponent<TrashCard>().affectEnemyAmount;
                                    }
                                }
                            }
                        }
                        else if (kategoriArea == "None")
                        {
                            Debug.Log("location unknown");
                            powers[i] = slot[i].MountedCards[0].GetComponent<TrashCard>().None;
                        }
                        else
                        {
                            powers[i] = slot[i].MountedCards[0].GetComponent<TrashCard>().Penalty;
                            //affectAlly
                            if (slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyArea &&
                                (slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition == ActiveCondition.FalseCategory ||
                                slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition == ActiveCondition.BothCategory))
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (j != GetArray())
                                    {
                                        Debug.Log("affect ally false category");
                                        if (slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition == ActiveCondition.FalseCategory)
                                        { allyCounter[j].power += slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyAmount; }
                                        else { allyCounter[j].power -= slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyAmount; }
                                    }
                                }
                            }
                            //affectEnemy
                            if (slot[i].MountedCards[0].GetComponent<TrashCard>().affectEnemyArea &&
                                slot[i].MountedCards[0].GetComponent<TrashCard>().affectEnemyCondition == ActiveCondition.FalseCategory ||
                                slot[i].MountedCards[0].GetComponent<TrashCard>().affectEnemyCondition == ActiveCondition.BothCategory)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (j != GetArray())
                                    {
                                        Debug.Log("affect ally false category");
                                        enemyCounter[j].power += slot[i].MountedCards[0].GetComponent<TrashCard>().affectEnemyAmount;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
        for (int i = 0; i < 4; i++)
        {
            if(powers[i] != 0)
            {
                if (slot[i].MountedCards[0].GetComponent<DragDetector>().IsActive)
                {
                    power += powers[i];
                }
            }
        }
    }

    public void DisplayPower()
    {
        for (int i = 0; i < 3; i++)
        {
            allyCounter[i].powerLabel.text = allyCounter[i].power.ToString();
        }
    }

    public void LockCard()
    {
        for(int i = 0; i < 4; i++)
        {
            try
            {
                if (slot[i].MountedCards != null)
                {
                    slot[i].MountedCards[0].GetComponent<DragDetector>().IsActive = false;
                }
            }
            catch { }
        }
    }

    private int GetArray()
    {
        for(int i = 0; i < 3; i++)
        {
            if(allyCounter[i].name == gameObject.name)
            {
                return i;
            }
        }
        return -1;
    }
}
