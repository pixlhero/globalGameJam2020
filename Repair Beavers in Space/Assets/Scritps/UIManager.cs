using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool _hasStartedFromMainScene; // used for debugging. e.g. skipping the UI introduction


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.sceneCount < 2)
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
        }
        else
        {
            _hasStartedFromMainScene = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
