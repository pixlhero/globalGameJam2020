using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepairState : MonoBehaviour
{
    public Rigidbody2D _rigidbody;

    public HullDamage hullDamage;
    public HullDamage currentlyRepairing;

    public void StartRepairing(Grabbable log)
    {
        currentlyRepairing = hullDamage;

        hullDamage = null;

        if (!currentlyRepairing.HasLog() && log != null)
            currentlyRepairing.GiveLog(log);

        TogglePhysics(false);
        currentlyRepairing.OnRepaired += StopRepairing;
        currentlyRepairing.JoinRepair(transform);
    }

    public void StopRepairing()
    {
        TogglePhysics(true);

        currentlyRepairing.LeaveRepair(transform);
        currentlyRepairing.OnRepaired -= StopRepairing;
        currentlyRepairing = null;
    }

    bool IsHullDamageInRange()
    {
        return hullDamage != null;
    }

    public bool IsRepairing()
    {
        return currentlyRepairing != null;
    }
    public bool CanStartRepairing(bool playerHasLog, out bool dropLog)
    {
        dropLog = false;
        if (hullDamage == null)
            return false;

        dropLog = hullDamage.HasLog();

        return (hullDamage.HasLog() || (!hullDamage.HasLog() && playerHasLog)) && hullDamage.CanJoinRepair;
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

    void TogglePhysics(bool on)
    {
        _rigidbody.isKinematic = !on;

        if (!on)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0;
        }
    }
}
