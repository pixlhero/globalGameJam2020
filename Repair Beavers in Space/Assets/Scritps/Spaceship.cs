using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public static Spaceship instance;

    private void Start()
    {
        instance = this;
    }
}
