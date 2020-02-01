using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class HullDamage : MonoBehaviour
{
    public Transform logAnchor;
    Grabbable log;

    int beaversRepairing = 0;

    public bool HasLog()
    {
        return log != null;
    }

    internal void JoinRepair(Transform playerTranform)
    {
        beaversRepairing++;
    }
    internal void LeaveRepair(Transform playerTransform)
    {
        beaversRepairing--;
        playerTransform.parent = null;
    }

    internal void GiveLog(Grabbable grabbable)
    {
        log = grabbable;
        log.transform.parent = logAnchor;
        log.transform.localPosition = Vector3.zero;
        log.transform.localRotation = Quaternion.identity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var playerActions = collision.GetComponent<PlayerRepairState>();

            playerActions.HullDamageIsNear(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var playerActions = collision.GetComponent<PlayerRepairState>();

            playerActions.HullDamageIsNoLongerNear(this);
        }
    }
}
