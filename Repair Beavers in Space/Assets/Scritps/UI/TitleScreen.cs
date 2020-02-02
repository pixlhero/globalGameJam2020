using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : UIScreen
{
    public CanvasGroup StartPrompt;

    public override void Hide()
    {
        transform.DOMove(this.transform.position + new Vector3(-1000, 0, 0), 1).SetEase(Ease.InSine).OnComplete(() => {
            this.gameObject.SetActive(false);
        });

        CanvasGroup group = this.GetComponent<CanvasGroup>();
        group.DOFade(0, 1).SetEase(Ease.InSine);
    }

    public override void Show()
    {
        this.gameObject.SetActive(true);

        StartPrompt.alpha = 0;

        CanvasGroup group = GetComponent<CanvasGroup>();
        group.alpha = 0;


        transform.position = this.transform.position + new Vector3(0, 300, 0);
        transform.DOMoveY(transform.position.y  - 300, 3).OnComplete(() =>
        {
            StartPrompt.DOFade(1, 1);
        });
        group.DOFade(1, 2).SetDelay(1);

    }

    private void Update()
    {
        if(Input.GetButtonDown("Start")){
            UIManager.Singleton.SwitchToState(UIManager.UIState.PLAYER_SELECT);
        }
    }
}
