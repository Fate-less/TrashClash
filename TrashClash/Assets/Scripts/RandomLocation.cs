using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Location
{
    None,
    Organik,
    Anorganik,
    Kertas,
    Residu,
    B3
}

public class RandomLocation : MonoBehaviour
{
    public Location firstLocation;
    public Location secondLocation;
    public Location thirdLocation;
    // Start is called before the first frame update

    void Start()
    {
        firstLocation = (Location) Random.Range(1, 5);
        secondLocation = (Location) Random.Range(1, 5);
        while(secondLocation == firstLocation)
        {
            secondLocation = (Location)Random.Range(1, 5);
        }
        thirdLocation = (Location) Random.Range(1, 5);
        while (thirdLocation == firstLocation || thirdLocation == secondLocation)
        {
            thirdLocation = (Location)Random.Range(1, 5);
        }
    }
}
