using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    public float spawnRadius = 10;

    private void Start()
    {
        instance = this;
    }
}
