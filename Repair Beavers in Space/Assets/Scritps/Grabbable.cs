using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Grabbable : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public new Collider2D collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GrabZone")
        {
            PlayerGrabbing playerGrabbing = other.GetComponent<PlayerGrabbing>();
            if (playerGrabbing == null)
                return;

            playerGrabbing.CanGrabThis(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "GrabZone")
        {
            PlayerGrabbing playerGrabbing = other.GetComponent<PlayerGrabbing>();
            if (playerGrabbing == null)
                return;

            playerGrabbing.CannotGrabThisAnymore(this);
        }
    }

    public void TogglePhysics(bool on)
    {
        _rigidbody.isKinematic = !on;
        _rigidbody.simulated = on;

        if (!on)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0;
        }
    }
}
