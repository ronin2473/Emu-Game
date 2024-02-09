using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public static Collider2D goal;
    public Collider2D player;
    float time;
    float time2;

    private void Start()
    {
        time = Time.realtimeSinceStartup;
        time2 = time;
        player = FindObjectOfType<Player_Movement>().GetComponent<Collider2D>();
    }

    public void Teleport(Transform goal)
    {
        time = Time.time;
        if (time >= time2) {
            time2 = time +5;
            player.transform.position = new Vector3(goal.position.x, goal.position.y,player.transform.position.z);
        }


    }




    // if point1 hit
    // teleport player to point2
    // if point2 hit
    // teleport player to point1
    //
}
