using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : UIScreen
{
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

        Vector3 originalPosition = this.transform.position;
        this.transform.position += new Vector3(400, 0, 0);
        transform.DOMove(originalPosition, 1).SetDelay(1);

        CanvasGroup group = this.GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.DOFade(1, 1).SetDelay(1);
    }
    private void Update()
    {
        //TODO
    }
}
