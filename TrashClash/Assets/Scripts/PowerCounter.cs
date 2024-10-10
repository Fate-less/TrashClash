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
    int tempPower = 0;

    public void CountPower()
    {
        for(int i = 0; i < 4; i++)
        {
            powers[i] = 0;
        }
        //try renew
        for(int i = 0; i < 4; i++)
        {
            try
            {
                if (slot[i].MountedCards != null)
                {
                    //ngitung power for each slot
                    if (kategoriArea == slot[i].MountedCards[0].GetComponent<TrashCard>().Kategori.ToString())
                    {
                        powers[i] = slot[i].MountedCards[0].GetComponent<TrashCard>().Value;
                        //Debuff
                        enemyCounter[i].powers[i] += slot[i].MountedCards[0].GetComponent<TrashCard>().Buff;
                        //affectAlly
                        if (slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyArea && 
                            slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition == ActiveCondition.TrueCategory ||
                            slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition == ActiveCondition.BothCategory)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (j != i)
                                {
                                    allyCounter[j].tempPower += slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyAmount;
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
                                if (j != i)
                                {
                                    enemyCounter[j].tempPower += slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyAmount;
                                }
                            }
                        }
                    }
                    else if (kategoriArea == "None")
                    {
                        powers[i] = slot[i].MountedCards[0].GetComponent<TrashCard>().None;
                    }
                    else
                    {
                        powers[i] = slot[i].MountedCards[0].GetComponent<TrashCard>().Penalty;
                        //affectAlly
                        if (slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyArea &&
                            slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition == ActiveCondition.FalseCategory ||
                            slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition == ActiveCondition.BothCategory)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (j != i)
                                {
                                    if (slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyCondition == ActiveCondition.FalseCategory)
                                    { allyCounter[j].tempPower += slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyAmount; }
                                    else { allyCounter[j].tempPower -= slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyAmount; }
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
                                if (j != i)
                                {
                                    enemyCounter[j].tempPower += slot[i].MountedCards[0].GetComponent<TrashCard>().affectAllyAmount;
                                }
                            }
                        }
                    }
                }
                else { powers[i] = 0; }
            }
            catch { }
        }
        for(int i = 0; i < 3; i++)
        {
            allyCounter[i].tempPower = 0;
            for(int j = 0; j < 4; j++)
            {
                allyCounter[i].tempPower += allyCounter[i].powers[j];
            }
            allyCounter[i].power = allyCounter[i].tempPower;
        }
        tempPower = 0;
        for (int i = 0; i < 4; i++)
        {
            tempPower += powers[i];
        }
        power = tempPower;
    }

    public void DisplayPower()
    {
        powerLabel.text = power.ToString();
        for(int i = 0; i < 3; i++)
        {
            allyCounter[i].powerLabel.text = allyCounter[i].power.ToString();
        }
    }

    private void Update()
    {
        DisplayPower();
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
}
