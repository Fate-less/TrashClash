using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOperator : MonoBehaviour
{
    public Material[] materials;

    public void SwapMaterial(int after)
    {
        gameObject.GetComponent<MeshRenderer>().material = materials[after];
    }
}
