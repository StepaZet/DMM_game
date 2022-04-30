using System.Collections;
using System.Collections.Generic;
using MainGameScripts;
using UnityEngine;

public class VacuumCleaner : PlayableObject
{
    public override void Move (Vector2 direction) 
    {
        if (BatteryCharge == 0) return;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x, 0), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
