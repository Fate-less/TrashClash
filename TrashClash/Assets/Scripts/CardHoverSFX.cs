using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHoverSFX : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void PlayCardHoverSFX()
    {
        audioManager.cardHovered();
    }
}
