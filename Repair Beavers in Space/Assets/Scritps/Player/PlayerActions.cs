using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerGrabbing playerGrabbing;
    public PlayerRepairState playerRepairState;

    // Update is called once per frame
    void Update()
    {
        if (!playerRepairState.IsRepairing())
        {
            if (Input.GetButtonDown("Flap"))
            {
                playerMovement.Flap();
            }

            if (Input.GetButtonDown("Grab"))
            {
                if (playerRepairState.CanStartRepairing(PlayerHasLog()))
                    playerRepairState.StartRepairing();
                else
                    playerGrabbing.ToggleGrabRelease();
            }

            Vector2 direction = Vector2.one;
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");

            playerMovement.AdjustDirection(direction);

            if (Input.GetButtonDown("Grab"))
            {
                //Stop Repairing
            }
        }
    }

    bool PlayerHasLog()
    {
        return playerGrabbing.HoldsLog();
    }
}
