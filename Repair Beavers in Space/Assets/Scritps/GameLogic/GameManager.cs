using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool _hasStartedFromThisScene; // used for debugging. e.g. skipping the UI introduction

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        { // to make starting from this scene possible
            SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
            _hasStartedFromThisScene = true;
        }
        instance = this;

        Camera.main.transform.DORotate(Vector3.zero, 2);
           
    }

    public void SetNumberOfPlayers(int number)
    {
        // TODO
    }

    public void StartGame()
    {
        //TODO
    }

    public void SetWinState()
    {
        //TODO
    }

    public void SetLoseState()
    {
        //TODO
    }
}
