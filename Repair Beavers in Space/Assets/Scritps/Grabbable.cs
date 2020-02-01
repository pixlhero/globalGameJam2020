using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Grabbable : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerGrabbing playerGrabbing = other.GetComponent<PlayerGrabbing>();
        if (playerGrabbing == null)
            return;

        playerGrabbing.CanGrabThis(this);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerGrabbing playerGrabbing = other.GetComponent<PlayerGrabbing>();
        if (playerGrabbing == null)
            return;

        playerGrabbing.CannotGrabThisAnymore(this);
    }
}
