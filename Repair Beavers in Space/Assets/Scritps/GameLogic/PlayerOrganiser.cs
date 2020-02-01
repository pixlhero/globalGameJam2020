using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrganiser : MonoBehaviour
{
    public static PlayerOrganiser instance;
    
    [Header("Prefabs")]
    public GameObject playerPrefab;
    public GameObject safetyLinePrefab;

    [Header("Settings")]
    [SerializeField] int playerCount;
    public int PlayerCount
    {
        get
        {
            return playerCount;
        }
        set
        {
            playerCount = Mathf.Clamp(value, 2, 4);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //Grab Player Count From PlayerMapping

        //Spawn n Players and give them the correct input mapping
        for (int i = 0; i < PlayerCount; i++)
        {
            SpawnPlayer(i, i);
        }
    }

    void SpawnPlayer(int playerNumber, int controllerNumber)
    {
        float angle = playerNumber * 360 / PlayerCount;

        float safetyLineRadius = Spaceship.Instance.size;
        float playerRadius = safetyLineRadius * 2;

        var dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        var player = Instantiate(playerPrefab, Spaceship.Position + dir * playerRadius, Quaternion.Euler(0,0, angle));
        var safetyLineObj = Instantiate(safetyLinePrefab, Spaceship.Position + dir * safetyLineRadius, Quaternion.Euler(0,0, angle));

        player.name = "Player " + playerNumber;

        var safetyLine = safetyLineObj.GetComponent<Safetyline>();

        player.GetComponent<PlayerActions>().playerNumber = controllerNumber;
        player.GetComponent<PlayerMovement>().safetyLine = safetyLine;
    }
}
