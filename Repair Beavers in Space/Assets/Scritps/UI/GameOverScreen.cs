using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : UIScreen
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
        //TODO
    }
}
