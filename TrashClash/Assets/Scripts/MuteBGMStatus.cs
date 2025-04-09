using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteBGMStatus : MonoBehaviour
{
    private AudioManager audioManager;
    private AudioSource audioSource;
    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (audioManager.bgmIsMuted) audioSource.mute = true;
        else audioSource.mute = false;
    }
}
