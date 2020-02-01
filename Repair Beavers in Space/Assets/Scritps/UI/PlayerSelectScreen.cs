using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectScreen : UIScreen{

    private ControllerMapping _controllerMapping;

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
        if(_controllerMapping == null)
        {
            _controllerMapping = FindObjectOfType<ControllerMapping>();
        }
        if(_controllerMapping == null)
        {
            Debug.LogError("ControllerMapping Object not found");
        }

        if (_controllerMapping.HasMapping(controllerID))
            return;

        ControllerMapping.BeaverType nextFreeType = _controllerMapping.GetNextAvailableType();
        int currentPlayers = _controllerMapping.NumberOfRegisteredPlayers;

        _controllerMapping.SetMapping(controllerID, nextFreeType);
    }
}
