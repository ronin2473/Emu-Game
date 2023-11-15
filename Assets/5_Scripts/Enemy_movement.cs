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
        Rigidbody rigi = enemy.GetComponent<Rigidbody>();
        rigi.velocity = Vector3.zero;
        Vector3 direction = Getposition();
        direction.x = direction.x - enemy.transform.position.x;
        direction.y = direction.y - enemy.transform.position.y;
        direction.z = direction.z - enemy.transform.position.z;
        Debug.Log(direction);
        direction.Normalize();
        Debug.Log(direction);
        rigi.AddForce(direction * speed * Time.deltaTime);

    }
}

