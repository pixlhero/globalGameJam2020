using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceObject : MonoBehaviour
{
    public float velocity;
    public float variationAngle;
    public float deathRange = 20;            //if the obj is further away from the spaceship than that it gets despawned

    [SerializeField, HideInInspector] protected Rigidbody2D rigi;

    Vector2 ShipCenter
    {
        get
        {
            if (Spaceship.Instance != null)
                return Spaceship.Instance.transform.position;
            else
                return Vector2.zero;
        }
    }

    Vector2 Position { get { return transform.position; } }

    protected virtual void Start()
    {
        rigi = GetComponent<Rigidbody2D>();

        rigi.velocity = GetStartDirection() * velocity;
    }

    void FixedUpdate()
    {
        Vector2 distance = ShipCenter - Position;

        if (distance.sqrMagnitude > deathRange * deathRange)
            Destroy(gameObject);
    }

    Vector2 GetStartDirection()
    {
        Vector2 towardsShip = ShipCenter - Position;
        float angle = Vector2.SignedAngle(Vector2.right, towardsShip) * Mathf.Deg2Rad;

        angle += Random.Range(-variationAngle * Mathf.Deg2Rad, variationAngle * Mathf.Deg2Rad);

        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        return direction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Position, Position + rigi.velocity);
    }

    private void OnValidate()
    {
        if (rigi == null)
            rigi = GetComponent<Rigidbody2D>();
    }
}
