using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    static Spaceship instance;
    public static Spaceship Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Spaceship>();

            return instance;
        }
    }

    public static Vector2 Position
    {
        get
        {
            return Instance.transform.position;
        }
    }

    public GameObject hullDamagePrefab;
    public float size = 5;

    public int maxHealth = 200;
    public float health;

    public List<GameObject> damages = new List<GameObject>();

    private void Awake()
    {
        instance = this;
        health = maxHealth;
    }

    private void Update()
    {
        health -= HullDamage.CURRENT_LEAKS * Time.deltaTime;

        if (health <= 0)
        {
            GameManager.instance.SetLoseState();
        }
    }

    public void CreateHullDamage(Vector2 position)
    {
        Vector2 direction = (position - (Vector2)transform.position).normalized;
        float angle = Vector2.SignedAngle(Vector2.up, direction);

        var damage = Instantiate(hullDamagePrefab, transform.position + (Vector3)direction * size, Quaternion.Euler(0, 0, angle), transform);

        damages.Add(damage);
    }
}
