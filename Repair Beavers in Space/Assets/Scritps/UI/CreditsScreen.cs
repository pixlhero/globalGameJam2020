using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreen : UIScreen
{
    public override void Hide()
    {
        SceneManager.LoadScene("UIScene");
    }

    public override void Show()
    {
        this.transform.position += new Vector3(0, -1000, 0);
        this.transform.DOMoveY(this.transform.position.y + 2000, 10).OnComplete(() => this.Hide());
    }
}
