using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMappingDummy : MonoBehaviour
{
    public int numberOfPlayers = 4;

    private void Awake()
    {
        if (Application.isEditor)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                ControllerMapping.SetMapping(i, (ControllerMapping.BeaverType)i);
            }
        }

        Destroy(this);
    }
}
