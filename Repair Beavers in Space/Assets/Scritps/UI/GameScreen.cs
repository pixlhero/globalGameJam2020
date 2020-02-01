using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen : UIScreen
{
    public override void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public override void Show()
    {
        this.gameObject.SetActive(true);
        SceneManager.LoadScene("GameplayScene", LoadSceneMode.Additive);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            UIManager.Singleton.SwitchToState(UIManager.UIState.WIN);
        }
    }
}
