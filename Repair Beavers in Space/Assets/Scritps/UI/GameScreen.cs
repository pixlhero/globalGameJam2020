using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen : UIScreen
{
    public override void Hide()
    {
        this.gameObject.SetActive(false);
        SceneManager.UnloadSceneAsync("GameplayScene");
        FindObjectOfType<SkyboxRotation>().SpeedUpShortly();

        FindObjectOfType<Soundtrack>().PlayCalmSound();

    }

    public override void Show()
    {
        this.gameObject.SetActive(true);
        SceneManager.LoadScene("GameplayScene", LoadSceneMode.Additive);

        FindObjectOfType<Soundtrack>().PlayGameSound();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UIManager.Singleton.SwitchToState(UIManager.UIState.WIN);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.Singleton.SwitchToState(UIManager.UIState.LOOSE);
        }
    }
}
