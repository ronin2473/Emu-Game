using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point1 : MonoBehaviour
{
    public Collider2D point2;
    public Teleporter teleporter;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col == teleporter.player)
        {
            teleporter.Teleport(point2.transform);
        }
    }
}
