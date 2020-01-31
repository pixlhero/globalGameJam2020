using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool disposed;
    private static object threadLock = new object();
    private static T instance;

    public static T Instance
    {
        get
        {
            if (disposed)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already disposed. Returning null.");
                return null;
            }

            lock (threadLock)
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return instance;
            }
        }
    }

    private void OnDestroy()
    {
        if (Application.isPlaying)
            disposed = true;
    }

    private void OnApplicationQuit()
    {
        disposed = true;
    }
}
