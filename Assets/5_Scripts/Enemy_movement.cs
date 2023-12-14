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
    public float speedMultiplier = 1800f;

    // Update is called once per frame
    void Update()
    {

        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            speed = enemy.GetComponent<EnemyStats>().speed * speedMultiplier;
            MoveEnemy(enemy);
            Debug.Log(speed);
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
        direction = direction - enemy.transform.position;
        direction.Normalize();
        rigi.AddForce(new Vector2(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime));
        
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

