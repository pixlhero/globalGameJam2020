using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}
