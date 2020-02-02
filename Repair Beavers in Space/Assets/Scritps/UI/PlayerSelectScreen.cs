using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectScreen : UIScreen{
    public int MinAmountOfPlayers = 1;

    public SelectChain Chain;

    public CanvasGroup StartPrompt;
    public override void Hide()
    {
        transform.DOMove(this.transform.position + new Vector3(-1000, 0, 0), 1).SetEase(Ease.InSine).OnComplete(()=> {
            this.gameObject.SetActive(false);
        });

        CanvasGroup group = this.GetComponent<CanvasGroup>();
        group.DOFade(0, 1).SetEase(Ease.InSine);

    }

    public override void Show()
    {
        StartPrompt.gameObject.SetActive(false);
        StartPrompt.alpha = 0;

        this.gameObject.SetActive(true);

        FindObjectOfType<SkyboxRotation>().SpeedUpShortly();


        Vector3 originalPosition = this.transform.position;
        this.transform.position += new Vector3(400, 0, 0);
        transform.DOMove(originalPosition, 1).SetDelay(1);

        CanvasGroup group = this.GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.DOFade(1, 1).SetDelay(1);

    }

    private void Update()
    {
        for(int controllerID = 0; controllerID <= 3; controllerID++)
        {
            if (Input.GetButtonDown("Flap " + (controllerID + 1)))
            {
                TryRegisterPlayer(controllerID);
            }
        }

        if (Input.GetButtonDown("Start") && ControllerMapping.NumberOfRegisteredPlayers >= MinAmountOfPlayers)
        {
            UIManager.Singleton.SwitchToState(UIManager.UIState.CUTSCENES);
        }
    }

    private void TryRegisterPlayer(int controllerID)
    {
        if (ControllerMapping.HasMapping(controllerID))
            return;

        ControllerMapping.BeaverType nextFreeType = ControllerMapping.GetNextAvailableType();
        int currentPlayers = ControllerMapping.NumberOfRegisteredPlayers;

        ControllerMapping.SetMapping(controllerID, nextFreeType);

        Chain.AddChain();

        if (ControllerMapping.NumberOfRegisteredPlayers >= MinAmountOfPlayers)
        {
            EnableStart();
        }
    }

    private void EnableStart()
    {
        StartPrompt.gameObject.SetActive(true);
        StartPrompt.DOFade(1, 1);

    }
}
