using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Enemy_movement : MonoBehaviour
{
    public float speed = 1f;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigi = this.GetComponent<Rigidbody>();
        rigi.velocity = Vector3.zero;
        Vector3 direction = Getposition();
        direction.x = Math.Sign(direction.x - this.transform.position.x);
        direction.y = Math.Sign(direction.y - this.transform.position.y);
        direction.z = Math.Sign(direction.z - this.transform.position.z);
        rigi.AddForce(direction*speed);
        
    }

    public Vector3 Getposition() {
        GameObject goal = GameObject.FindGameObjectWithTag("Player");
        return goal.transform.position;
        
    }
}
