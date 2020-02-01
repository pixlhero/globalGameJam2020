using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner instance;

    public GameObject playerPrefab;
    public GameObject safetyLinePrefab;

    int playerNumber;
    public int PlayerNumber
    {
        get
        {
            return playerNumber;
        }
        set
        {
            playerNumber = Mathf.Clamp(value, 2, 4);
        }
    }

    private void Start()
    {
        //Grab Player Number From PlayerMapping

        //Spawn n Players and give them the correct input mapping
    }
}
