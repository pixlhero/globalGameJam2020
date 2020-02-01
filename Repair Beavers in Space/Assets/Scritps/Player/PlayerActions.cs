using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public enum State { Default, Repairing }

    public State state = State.Default;

    public PlayerMovement playerMovement;
    public PlayerGrabbing playerGrabbing;

    public HullDamage hullDamage;
    public HullDamage currentlyRepairing;

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Default:
                if (Input.GetButtonDown("Flap"))
                {
                    playerMovement.Flap();
                }

                if (Input.GetButtonDown("Grab"))
                {
                    if (IsHullDamageInRange())
                    {
                        if (!hullDamage.HasLog() && PlayerHasLog())
                        {
                            hullDamage.GiveLog(playerGrabbing.GiveLog());
                        }

                        if ((hullDamage.HasLog() && !PlayerHasLog()))
                        {
                            StartRepairing();
                        }
                        else
                        {
                            playerGrabbing.ToggleGrabRelease();
                        }
                    }
                    else
                    {
                        playerGrabbing.ToggleGrabRelease();
                    }
                }

                Vector2 direction = Vector2.one;
                direction.x = Input.GetAxis("Horizontal");
                direction.y = Input.GetAxis("Vertical");

                Debug.Log(direction);

                playerMovement.AdjustDirection(direction);
                break;

            case State.Repairing:
                if (Input.GetButtonDown("Grab"))
                {
                    //Stop Repairing
                }
                break;
        }
    }

    private void StartRepairing()
    {
        currentlyRepairing = hullDamage;

        hullDamage = null;

        state = State.Repairing;
        hullDamage.JoinRepair(transform);
    }

    private void StopRepairing()
    {
        state = State.Default;
    }

    bool IsHullDamageInRange()
    {
        return hullDamage != null;
    }

    bool PlayerHasLog()
    {
        return playerGrabbing.HoldsLog();
    }

    public void HullDamageIsNear(HullDamage hd)
    {
        hullDamage = hd;
    }
    public void HullDamageIsNoLongerNear(HullDamage hd)
    {
        if (hullDamage == hd)
            hullDamage = null;
    }
}
