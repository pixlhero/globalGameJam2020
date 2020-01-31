using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public PlayerMovement playerMovement;
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Flap"))
        {
            playerMovement.Flap();
        }

        Vector2 direction = Vector2.one;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        playerMovement.AdjustDirection(direction);
    }
}
