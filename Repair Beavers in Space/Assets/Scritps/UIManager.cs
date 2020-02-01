using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool _hasStartedFromMainScene; // used for debugging. e.g. skipping the UI introduction

    public static UIManager Singleton;

    public UIScreen[] scenesInOrder;

    public enum UIState
    {
        START_SCREEN,
        PLAYER_SELECT,
        CUTSCENES,
        HOWTOPLAY,
        GAME,
        LOOSE,
        WIN
    }

    private UIState _currentState;

    // Start is called before the first frame update
    void Start()
    {
        if(UIManager.Singleton != null)
        {
            Debug.LogError("Multiple UI Managers!");
        }
        UIManager.Singleton = this;

        if (SceneManager.sceneCount < 2)
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
        }
        else
        {
            _hasStartedFromMainScene = true;
        }

        foreach(UIScreen state in scenesInOrder)
        {
            state.gameObject.SetActive(false);
        }

        SetToState(UIState.START_SCREEN);
        this._currentState = UIState.START_SCREEN;
    }

    public void SwitchToState(UIState newState)
    {
        LeaveCurrentState();
        SetToState(newState);

        this._currentState = newState;
    }

    private void SetToState(UIState newState)
    {
        int sceneID = (int)newState;
        scenesInOrder[sceneID].Show();
    }

    private void LeaveCurrentState()
    {
        int sceneID = (int)_currentState;
        scenesInOrder[sceneID].Hide();
    }



}
