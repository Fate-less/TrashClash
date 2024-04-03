using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    [SerializeField] PowerCounter area1;
    [SerializeField] PowerCounter area2;
    [SerializeField] PowerCounter area3;
    public TextMeshProUGUI phaseLabel;
    public int round;
    private int phase;

    private void Update()
    {
        if(phase >= 2)
        {
            round++;
            phase = 0;
        }
        if(round >= 6)
        {
            //game end
            //hitung p1 ato p2 menang
        }
    }

    public void ChangePhase()
    {
        if(phase == 0)
        {
            //buka kartu
            //energy nambah
        }
        if(phase == 1)
        {
            area1.LockCard();
            area2.LockCard();
            area3.LockCard();
            //kunci kartu
            //tutup kartu
            //rotate
        }
        phase++;
    }

    void ShowPhase()
    {
        if (phase == 0)
        {
            phaseLabel.text = "Show Card";
        }
        if(phase == 1)
        {
            phaseLabel.text = "End Turn";
        }
    }
}

