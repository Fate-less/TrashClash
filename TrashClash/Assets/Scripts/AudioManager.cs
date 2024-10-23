using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Category")]
    public AudioClip[] anorganikTrash; //2
    public AudioClip[] b3Trash; //2
    public AudioClip[] kertasTrash; //1
    public AudioClip[] organikTrash; //1
    public AudioClip[] residuTrash; //1

    [Header("Extras")]
    public AudioClip[] cardHover; //1
    public AudioClip[] cardPick; //2
    public AudioClip[] mainMenuButtonClick; //1
    public AudioClip[] mainMenuButtonHover; //1
    public AudioClip[] trashbinReveal; //1
    public AudioClip[] nextTurnButton; //3
    public AudioClip[] winning; //2

    //Singleton (currently not needed)
    //public void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //    }
    //    instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    public void anorganikTrashed()
    {
        int randomValue = Random.Range(1,2);
        if(randomValue == 1) { AudioSource.PlayClipAtPoint(anorganikTrash[0], Camera.main.transform.position); }
        else { AudioSource.PlayClipAtPoint(anorganikTrash[1], Camera.main.transform.position); }
    }
    public void b3Trashed()
    {
        int randomValue = Random.Range(1, 2);
        if (randomValue == 1) { AudioSource.PlayClipAtPoint(b3Trash[0], Camera.main.transform.position); }
        else { AudioSource.PlayClipAtPoint(b3Trash[1], Camera.main.transform.position); }
    }
    public void kertasTrashed()
    {
        AudioSource.PlayClipAtPoint(kertasTrash[0], Camera.main.transform.position);
    }
    public void organikTrashed()
    {
        AudioSource.PlayClipAtPoint(organikTrash[0], Camera.main.transform.position);
    }
    public void residuTrashed()
    {
        AudioSource.PlayClipAtPoint(residuTrash[0], Camera.main.transform.position);
    }
    public void cardHovered()
    {
        AudioSource.PlayClipAtPoint(cardHover[0], Camera.main.transform.position);
    }
    public void cardPicked()
    {
        int randomValue = Random.Range(1, 2);
        if (randomValue == 1) { AudioSource.PlayClipAtPoint(cardPick[0], Camera.main.transform.position); }
        else { AudioSource.PlayClipAtPoint(cardPick[1], Camera.main.transform.position); }
    }
    public void mainMenuButtonClicked()
    {
        AudioSource.PlayClipAtPoint(mainMenuButtonClick[0], Camera.main.transform.position);
    }
    public void mainMenuButtonHovered()
    {
        AudioSource.PlayClipAtPoint(mainMenuButtonHover[0], Camera.main.transform.position);
    }
    public void trashbinRevealed()
    {
        AudioSource.PlayClipAtPoint(trashbinReveal[0], Camera.main.transform.position);
    }
    public void nextTurnButtonClicked()
    {
        int randomValue = Random.Range(1, 3);
        if (randomValue == 1) { AudioSource.PlayClipAtPoint(nextTurnButton[0], Camera.main.transform.position); }
        else if (randomValue == 2) { AudioSource.PlayClipAtPoint(nextTurnButton[1], Camera.main.transform.position); }
        else { AudioSource.PlayClipAtPoint(nextTurnButton[2], Camera.main.transform.position); }
    }
    public void playerWinning()
    {
        int randomValue = Random.Range(1, 2);
        if (randomValue == 1) { AudioSource.PlayClipAtPoint(winning[0], Camera.main.transform.position); }
        else { AudioSource.PlayClipAtPoint(winning[1], Camera.main.transform.position); }
    }
}
