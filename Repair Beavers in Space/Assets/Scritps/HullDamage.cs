using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class HullDamage : MonoBehaviour
{
    public static int CURRENT_LEAKS;

    public delegate void DamageEvent();
    public DamageEvent OnRepaired;

    public Transform logAnchor;
    float logHeight = 0.5f;
    public Transform repairAnchorRight;
    public Transform repairAnchorLeft;

    public AudioClip[] clips = new AudioClip[5];
    public AudioSource sfxSource;

    public GameObject repairedEffect;

    float repairTime;
    public float maxRepairTime = 5;

    Grabbable log;

    int beaversRepairing = 0;
    public bool CanJoinRepair { get { return beaversRepairing < 2; } }

    private void Start()
    {
        logHeight = logAnchor.localPosition.y;
        CURRENT_LEAKS++;

        sfxSource.clip = clips[UnityEngine.Random.Range(0, 5)];
        sfxSource.Play();
    }

    private void Update()
    {

        if (repairTime >= maxRepairTime)
        {
            FixDamage();
            return;
        }

        if (beaversRepairing == 1)
        {
            repairTime += Time.deltaTime;
        }
        else if (beaversRepairing == 2)
        {
            repairTime += Time.deltaTime * 2.5f;
        }
    }

    private void FixedUpdate()
    {
        var pos = logAnchor.localPosition;
        pos.y = logHeight - Mathf.InverseLerp(0, maxRepairTime, repairTime) * logHeight * 2;

        logAnchor.localPosition = pos;
    }

    public bool HasLog()
    {
        return log != null;
    }

    internal void JoinRepair(Transform playerTransform)
    {
        beaversRepairing++;

        //Choose which repair anchor is closer
        var playerPos = playerTransform.position;

        if ((playerPos - repairAnchorRight.position).sqrMagnitude < (playerPos - repairAnchorLeft.position).sqrMagnitude)
            playerTransform.parent = repairAnchorRight;
        else
            playerTransform.parent = repairAnchorLeft;

        playerTransform.localPosition = Vector3.zero;
        playerTransform.localRotation = Quaternion.identity;
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

    void FixDamage()
    {
        var fx = Instantiate(repairedEffect, transform.position, transform.rotation, transform);
        fx.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        fx.transform.parent = null;


        OnRepaired?.Invoke();
        Destroy(gameObject);

        CURRENT_LEAKS--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var playerActions = collision.GetComponent<PlayerRepairState>();

            playerActions.HullDamageIsNear(this);
            return;
        }
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
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
