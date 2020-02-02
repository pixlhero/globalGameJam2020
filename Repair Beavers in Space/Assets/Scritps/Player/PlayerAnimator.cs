using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator anim;

    internal void Flap()
    {
        anim.SetTrigger("flap");
    }

    internal void IsGrabbing(bool v)
    {
        anim.SetBool("isGrabbing", v);
    }

    internal void IsRepairing(bool v)
    {
        anim.SetBool("isRepairing", v);
    }
}
