﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public float spawnRadius = 10;
    public float aspectRatio = 1;

    #region Test
    public GameObject testPrefab;

    float time;
    float deltaTime = .5f;
    #endregion

    void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Time.time > time + deltaTime)
        {
            time = Time.time;
            SpawnObj(testPrefab);
        }        
    }

    void SpawnObj(GameObject obj)
    {
        Instantiate(obj, GetRandomPosition(), Quaternion.identity);
    }

    Vector2 GetRandomPosition()
    {
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        return GetPositionFromAngle(angle);
    }

    Vector2 GetPositionFromAngle(float angle)
    {
        Vector2 pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle) / aspectRatio) * spawnRadius;
        return pos;
    }

    public static void Spawn(GameObject obj)
    {
        instance.SpawnObj(obj);
    }

    private void OnDrawGizmos()
    {
        int nPoints = 30;
        float angleStep = Mathf.PI * 2 / nPoints;

        Gizmos.color = Color.red;

        for (int i = 0; i < nPoints; i++)
        {
            var pos = GetPositionFromAngle(angleStep * i);
            Gizmos.DrawWireSphere(pos, 0.1f);
        }
    }
}