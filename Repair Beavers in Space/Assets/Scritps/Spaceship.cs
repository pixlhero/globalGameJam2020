using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    static Spaceship instance;

    public GameObject hullDamagePrefab;
    public float size = 5;

    public List<GameObject> damages = new List<GameObject>();

    public static Spaceship Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Spaceship>();

            return instance;
        }
    }

    private void Start()
    {
        instance = this;
    }

    public void CreateHullDamage(Vector2 position)
    {
        Vector2 direction = (position - (Vector2)transform.position).normalized;
        float angle = Vector2.SignedAngle(Vector2.up, direction);

        var damage = Instantiate(hullDamagePrefab, transform.position + (Vector3)direction * size, Quaternion.Euler(0, 0, angle), transform);

        damages.Add(damage);
    }
}
