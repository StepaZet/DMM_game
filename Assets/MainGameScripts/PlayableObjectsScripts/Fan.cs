using System;
using System.Collections;
using System.Collections.Generic;
using MainGameScripts;
using UnityEngine;

public class Fan : PlayableObject
{
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    public override void Move (Vector2 direction) 
    {
        if (BatteryCharge == 0) return;
        var target = Quaternion.Euler(direction * tiltAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 5) * transform.right, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
