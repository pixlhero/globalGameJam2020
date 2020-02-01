using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool _hasStartedFromThisScene; // used for debugging. e.g. skipping the UI introduction

    private void Start()
    {
        if (SceneManager.sceneCount < 2)
        { // to make starting from this scene possible
            SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
            _hasStartedFromThisScene = true;
        }
    }

    public void SetNumberOfPlayers(int number)
    {
        // TODO
    }

    public void StartGame()
    {
        //TODO
    }
}
