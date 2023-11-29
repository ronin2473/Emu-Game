using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy_movement : MonoBehaviour
{
    public float speed = 1f;
    

    // Update is called once per frame
    void Update()
    {


        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            MoveEnemy(enemy);
        }
        
        
        
    }

    public Vector3 Getposition() {
        GameObject goal = GameObject.FindGameObjectWithTag("Player");
        return goal.transform.position;
    }

    public void MoveEnemy(GameObject enemy)
    {
        Rigidbody2D rigi = enemy.GetComponent<Rigidbody2D>();
        rigi.velocity = Vector3.zero;
        Vector3 direction = Getposition();
        direction.x = direction.x - enemy.transform.position.x;
        direction.y = direction.y - enemy.transform.position.y;
        direction.z = direction.z - enemy.transform.position.z;
        direction.Normalize();
        rigi.AddForce(direction * speed * Time.deltaTime);
        if (direction.x < 0)
        {
            enemy.transform.localScale = new Vector3(-Math.Abs(enemy.transform.localScale.x), enemy.transform.localScale.y, enemy.transform.localScale.z);
        }
        if (direction.x > 0)
        {
            enemy.transform.localScale = new Vector3(Math.Abs(enemy.transform.localScale.x), enemy.transform.localScale.y, enemy.transform.localScale.z);
        }

    }
}

