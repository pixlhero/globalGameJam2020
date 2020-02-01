using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectScreen : UIScreen{

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
        for(int controllerID = 0; controllerID <= 3; controllerID++)
        {
            if (Input.GetButtonDown("Flap " + controllerID))
            {
                TryRegisterPlayer(controllerID);
            }
        }

        


        if (Input.GetButtonDown("Start"))
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
    }
}
