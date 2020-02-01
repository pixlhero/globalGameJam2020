using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChain : MonoBehaviour
{
    public GameObject[] chainElementsInOrder;

    private int nextActiveChainID = 0;

    private void Awake()
    {
        foreach(GameObject chainEl in chainElementsInOrder)
        {
            chainEl.SetActive(false);
        }
    }

    public void AddChain()
    {
        chainElementsInOrder[nextActiveChainID].SetActive(true);
        nextActiveChainID++;
    }

}
