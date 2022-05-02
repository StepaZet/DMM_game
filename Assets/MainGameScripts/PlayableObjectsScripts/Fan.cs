using System;
using System.Collections;
using System.Collections.Generic;
using MainGameScripts;
using UnityEngine;

public class Fan : PlayableObject
{
    public AudioSource fans;
    float smooth = 7.0f;
    float tiltAngle = 60.0f;
    public override void Move (Vector2 direction) 
    {
        if (BatteryCharge <= 0) return;
        var target = Quaternion.Euler(0,0 ,-direction.x * tiltAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fans.Play();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 10) * transform.up, ForceMode2D.Impulse);
        }
        if(direction != Vector2.zero)
            DeCharge(0.009);
    }
}
