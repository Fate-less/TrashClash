using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempatSampahAnim : MonoBehaviour
{
    private Animator animator;

    //public Animation tempatSampahAnorganikAnim;
    //public Animation tempatSampahB3Anim;
    //public Animation tempatSampahKertasAnim;
    //public Animation tempatSampahOrganikAnim;
    //public Animation tempatSampahResiduAnim;
    public RandomLocation randomLocation;
    // Start is called before the first frame update
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void FirstLocationAnim()
    {
        if(randomLocation.firstLocation == Location.Anorganik)
        {
            animator.Play("Tempat Sampah Anorganik");
        }
        else if (randomLocation.firstLocation == Location.B3)
        {
            animator.Play("Tempat Sampah B3");
        }
        else if (randomLocation.firstLocation == Location.Kertas)
        {
            animator.Play("Tempat Sampah Kertas");
        }
        else if (randomLocation.firstLocation == Location.Organik)
        {
            animator.Play("Tempat Sampah Organik");
        }
        else if (randomLocation.firstLocation == Location.Residu)
        {
            animator.Play("Tempat Sampah Residu");
        }
    }

    public void SecondLocationAnim()
    {
        if (randomLocation.secondLocation == Location.Anorganik)
        {
            animator.Play("Tempat Sampah Anorganik");
        }
        else if (randomLocation.secondLocation == Location.B3)
        {
            animator.Play("Tempat Sampah B3");
        }
        else if (randomLocation.secondLocation == Location.Kertas)
        {
            animator.Play("Tempat Sampah Kertas");
        }
        else if (randomLocation.secondLocation == Location.Organik)
        {
            animator.Play("Tempat Sampah Organik");
        }
        else if (randomLocation.secondLocation == Location.Residu)
        {
            animator.Play("Tempat Sampah Residu");
        }
    }

    public void ThirdLocationAnim()
    {
        if (randomLocation.thirdLocation == Location.Anorganik)
        {
            animator.Play("Tempat Sampah Anorganik");
        }
        else if (randomLocation.thirdLocation == Location.B3)
        {
            animator.Play("Tempat Sampah B3");
        }
        else if (randomLocation.thirdLocation == Location.Kertas)
        {
            animator.Play("Tempat Sampah Kertas");
        }
        else if (randomLocation.thirdLocation == Location.Organik)
        {
            animator.Play("Tempat Sampah Organik");
        }
        else if (randomLocation.thirdLocation == Location.Residu)
        {
            animator.Play("Tempat Sampah Residu");
        }
    }
}
