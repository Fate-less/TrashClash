using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;

public class TrashedSFX : MonoBehaviour
{
    private CardGroup cardGroup;
    public AudioManager audioManager;

    private void Start()
    {
        cardGroup = GetComponent<CardGroup>();
    }

    public void PlayTrashedSound()
    {
        try
        {
            if (cardGroup.MountedCards[0] != null)
            {
                if (cardGroup.MountedCards[0].GetComponent<TrashCard>().Kategori == TrashType.Organik)
                {
                    audioManager.organikTrashed();
                }
                else if (cardGroup.MountedCards[0].GetComponent<TrashCard>().Kategori == TrashType.Anorganik)
                {
                    audioManager.anorganikTrashed();
                }
                else if (cardGroup.MountedCards[0].GetComponent<TrashCard>().Kategori == TrashType.Kertas)
                {
                    audioManager.kertasTrashed();
                }
                else if (cardGroup.MountedCards[0].GetComponent<TrashCard>().Kategori == TrashType.Residu)
                {
                    audioManager.residuTrashed();
                }
                else if (cardGroup.MountedCards[0].GetComponent<TrashCard>().Kategori == TrashType.B3)
                {
                    audioManager.b3Trashed();
                }
            }
        }
        catch { }
    }
}
