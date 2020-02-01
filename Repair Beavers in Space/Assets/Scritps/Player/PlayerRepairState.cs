using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepairState : MonoBehaviour
{
    public Rigidbody2D _rigidbody;

    public HullDamage hullDamage;
    public HullDamage currentlyRepairing;

    public void StartRepairing()
    {
        currentlyRepairing = hullDamage;

        hullDamage = null;

        TogglePhysics(false);
        currentlyRepairing.JoinRepair(transform);
    }

    private void StopRepairing()
    {
        TogglePhysics(true);
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
    public bool CanStartRepairing(bool playerHasLog)
    {
        if (hullDamage == null)
            return false;

        return ((hullDamage.HasLog() && !playerHasLog) || (!hullDamage.HasLog() && playerHasLog));
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
        _rigidbody.simulated = on;

    }
}
