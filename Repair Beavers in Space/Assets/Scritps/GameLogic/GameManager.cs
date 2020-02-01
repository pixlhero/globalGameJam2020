using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum State { intro, gameplay, win, lose }
    public static State CurrentState { get; private set; } = State.intro;

    public static GameManager instance;
    private bool _hasStartedFromThisScene; // used for debugging. e.g. skipping the UI introduction

    [Header("Transitions")]
    public int startTransitionTime = 5;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        { // to make starting from this scene possible
            SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
            _hasStartedFromThisScene = true;
        }
    }

    private void Start()
    {
        instance = this;

        Camera.main.transform.DORotate(Vector3.zero, startTransitionTime);

        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startTransitionTime);
        StartGame();
    }

    public void StartGame()
    {
        //TODO
        CurrentState = State.gameplay;
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
