using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public int playerNumber;

    public PlayerMovement playerMovement;
    public PlayerGrabbing playerGrabbing;
    public PlayerRepairState playerRepairState;

    string Flap { get { return "Flap" + InputNumber; } }
    string Grab { get { return "Grab" + InputNumber; } }
    string Horizontal { get { return "Horizontal" + InputNumber; } }
    string Vertical { get { return "Vertical" + InputNumber; } }

    string InputNumber { get { return " " + (playerNumber + 1); } }

    // Update is called once per frame
    void Update()
    {
        if (!playerRepairState.IsRepairing())
        {
            if (Input.GetButtonDown(Flap))
            {
                playerMovement.Flap();
            }

            if (Input.GetButtonDown(Grab))
            {
                if (playerRepairState.CanStartRepairing(PlayerHasLog()))
                    playerRepairState.StartRepairing(playerGrabbing.GiveLog());
                else
                    playerGrabbing.ToggleGrabRelease();
            }

            Vector2 direction = Vector2.one;
            direction.x = Input.GetAxis(Horizontal);
            direction.y = Input.GetAxis(Vertical);

            playerMovement.AdjustDirection(direction);
        }
        else
        {
            if (Input.GetButtonDown(Grab))
            {
                playerRepairState.StopRepairing();
            }
        }
    }

    bool PlayerHasLog()
    {
        return playerGrabbing.HoldsLog();
    }
}
