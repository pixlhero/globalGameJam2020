using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    static Spawner instance;
    public float spawnRadius = 10;
    public float aspectRatio = 1;

    public Transform debrisAnchor;

    [Header("Prefabs")]
    public GameObject asteroidPrefab;
    public GameObject logPrefab;

    void Awake()
    {
        instance = this;
    }
    
    void SpawnObj(GameObject obj)
    {
        Quaternion rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        Instantiate(obj, GetRandomPosition(), rotation, debrisAnchor);
    }

    Vector2 GetRandomPosition()
    {
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        return GetPositionFromAngle(angle);
    }

    Vector2 GetPositionFromAngle(float angle)
    {
        Vector2 pos = (Vector2)Spaceship.Instance.transform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle) / aspectRatio) * spawnRadius;
        return pos;
    }

    public static void SpawnAsteroid()
    {
        instance._SpawnAsteroid();
    }
    void _SpawnAsteroid()
    {
        SpawnObj(asteroidPrefab);
    }

    public static void SpawnWood()
    {
        instance._SpawnWood();
    }
    void _SpawnWood()
    {
        SpawnObj(logPrefab);
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
