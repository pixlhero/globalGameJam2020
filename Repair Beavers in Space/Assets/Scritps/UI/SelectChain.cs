using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChain : MonoBehaviour
{
    public GameObject[] chainElementsInOrder;

    private int nextActiveChainID = 0;

    public void AddChain()
    {
        chainElementsInOrder[nextActiveChainID].SetActive(true);
        nextActiveChainID++;
    }

}
