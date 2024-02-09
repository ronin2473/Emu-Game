using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Collider2D point1;
    public Collider2D point2;
    Transform player;

    private void Start()
    {
        player = FindObjectOfType<Player_Movement>().transform;
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger = point1)
        {
            player.position = point2.transform.position;
        }

        if (trigger = point2)
        {
            player.position = point2.transform.position;
        }
    }




    // if point1 hit
    // teleport player to point2
    // if point2 hit
    // teleport player to point1
    //
}
