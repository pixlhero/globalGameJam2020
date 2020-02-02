using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutscenesScreen : UIScreen
{
    public Sprite[] cutscenesInOrder;

    private AudioSource source;

    public AudioClip[] clips;

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

        source = GetComponent<AudioSource>();

        this.gameObject.SetActive(true);

        FindObjectOfType<SkyboxRotation>().SpeedUpShortly();

        Vector3 originalPosition = this.transform.position;
        this.transform.position += new Vector3(1000, 0, 0);
        transform.DOMove(originalPosition, 1).SetDelay(1);

        CanvasGroup group = this.GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.DOFade(1, 1).SetDelay(1);

        PlayNextClip(0);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            this.Hide();
        }

        if (TestForNextScene())
        {
            if (currentCutsceneIndex >= cutscenesInOrder.Length - 1)
            {
                UIManager.Singleton.SwitchToState(UIManager.UIState.GAME);
            }
            else
            {
                currentCutsceneIndex++;

                PlayNextClip(currentCutsceneIndex);

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

    private void PlayNextClip(int index)
    {
        if(index == 0)
        {
            source.volume = 0;
            source.clip = clips[index];
            source.DOFade(1, 0.5f);
            source.Play();
        }
        else
        {
            source.DOFade(0, 2).OnComplete(() =>
            {
                source.Stop();
                source.clip = clips[index];
                if(source.clip != null)
                {
                    source.Play();
                }
                source.DOFade(1, 0.5f);
            });

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
