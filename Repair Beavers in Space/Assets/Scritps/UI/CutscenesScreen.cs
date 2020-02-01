using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenesScreen : UIScreen
{
    public override void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public override void Show()
    {
        this.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            UIManager.Singleton.SwitchToState(UIManager.UIState.HOWTOPLAY);
        }
    }
}
