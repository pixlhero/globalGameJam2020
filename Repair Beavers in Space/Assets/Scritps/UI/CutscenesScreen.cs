using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutscenesScreen : UIScreen
{
    public Sprite[] cutscenesInOrder;

    public Transform cutsceneParent;

    public Image CutsceneImage;

    private int currentCutsceneIndex;

    private bool canRotate = true;

    public override void Hide()
    {
        CanvasGroup group = this.GetComponent<CanvasGroup>();

        group.DOFade(0, 1.5f);


        FindObjectOfType<SkyboxRotation>().SpeedUpShortly();

        cutsceneParent.DOMoveX(cutsceneParent.position.x - 700, 1.5f).SetEase(Ease.InSine).OnComplete(() => {
            this.gameObject.SetActive(false);
        });


    }

    public override void Show()
    {
        this.gameObject.SetActive(true);


        FindObjectOfType<SkyboxRotation>().SpeedUpShortly();

        Vector3 originalPosition = this.transform.position;
        this.transform.position += new Vector3(1000, 0, 0);
        transform.DOMove(originalPosition, 1);

        CanvasGroup group = this.GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.DOFade(1, 1);

    }
    private void Update()
    {
        if (TestForNextScene())
        {
            if (currentCutsceneIndex >= cutscenesInOrder.Length - 1)
            {
                UIManager.Singleton.SwitchToState(UIManager.UIState.GAME);
            }
            else
            {
                currentCutsceneIndex++;

                canRotate = false;

                CanvasGroup group = cutsceneParent.GetComponent<CanvasGroup>();

                group.DOFade(0, 1.5f).SetEase(Ease.InSine).OnComplete(() => {
                    group.DOFade(1, 1.5f);
                });

                cutsceneParent.DOMoveX(cutsceneParent.position.x - 300, 1.5f).SetEase(Ease.InSine).OnComplete(() => {
                    CutsceneImage.sprite = cutscenesInOrder[currentCutsceneIndex];
                    cutsceneParent.position = cutsceneParent.position + new Vector3(600, 0, 0);
                    cutsceneParent.DOMoveX(cutsceneParent.position.x - 300, 1.5f).OnComplete(() => {
                        canRotate = true;
                    });
                });
            }
        }

    }

    private bool TestForNextScene()
    {
        if (!canRotate)
            return false;

        for (int controllerID = 0; controllerID <= 3; controllerID++)
        {
            if (Input.GetButtonDown("Flap " + (controllerID + 1)))
            {
                return true;
            }
        }
        return false;
    }
}
