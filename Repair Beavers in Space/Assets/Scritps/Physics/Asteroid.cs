using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Asteroid : SpaceObject
{
    new CircleCollider2D collider;

    protected override void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        base.Start();
    }

    private void CreateDamage()
    {
        //Spawn Spaceship Hulldamage
        Spaceship.Instance.CreateHullDamage(transform.position);
        //Despawn this object
        //Create explotion fx
        Explode();
    }

    void Explode()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spaceship")
        {
            if (rigi.velocity.magnitude > velocity / 2)
                CreateDamage();
        }
        else if (collision.gameObject.tag == "Asteroid")
        {
            Explode();
        }
    }
}
