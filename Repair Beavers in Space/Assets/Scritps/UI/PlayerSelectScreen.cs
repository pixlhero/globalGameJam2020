using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectScreen : UIScreen{
    public int MinAmountOfPlayers = 1;

    public SelectChain Chain;

    public GameObject StartPrompt;
    public override void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public override void Show()
    {
        StartPrompt.SetActive(false);
        this.gameObject.SetActive(true);
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
        StartPrompt.SetActive(true);
    }
}
