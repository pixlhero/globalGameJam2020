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

    float time;
    public float spawnTimeStep = 3;

    private void Awake()
    {
        instance = this;
        CurrentState = State.intro;
        if (SceneManager.GetActiveScene().buildIndex == 2)
        { // to make starting from this scene possible
            SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
            _hasStartedFromThisScene = true;
        }
    }

    private void Start()
    {
        Spawner.SpawnWood();
        Spawner.SpawnWood();

        Camera.main.transform.DORotate(Vector3.zero, startTransitionTime);

        StartCoroutine("StartDelay");
    }

    private void Update()
    {
        if (CurrentState == State.gameplay)
        {
            if (Time.time >= time + spawnTimeStep)
            {
                time = Time.time;
                if (HullDamage.CURRENT_LEAKS < PlayerOrganiser.instance.PlayerCount + 1)
                {
                    Spawner.SpawnAsteroid();
                }

                if (Log.LOG_COUNT < HullDamage.CURRENT_LEAKS * 2)
                    Spawner.SpawnWood();
            }
        }
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
        CurrentState = State.win;
        UIManager.Singleton.SwitchToState(UIManager.UIState.WIN);
    }

    public void SetLoseState()
    {
        CurrentState = State.lose;
        UIManager.Singleton.SwitchToState(UIManager.UIState.LOOSE);
    }
}
