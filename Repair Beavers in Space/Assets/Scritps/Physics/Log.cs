using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public static int LOG_COUNT;

    private void Start()
    {
        LOG_COUNT++;
    }

    private void OnDestroy()
    {
        LOG_COUNT--;
    }
}
