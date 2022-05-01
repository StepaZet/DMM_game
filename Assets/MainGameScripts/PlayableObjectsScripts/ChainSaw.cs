using System.Collections;
using System.Collections.Generic;
using MainGameScripts;
using UnityEngine;

public class ChainSaw : PlayableObject
{
    public override void Move (Vector2 direction) 
    {
        GetComponent<Rigidbody2D>().AddForce(direction*5, ForceMode2D.Impulse);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().WakeUp();
    }

    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.GetComponent<DeathScript>()) return;
        var diff = transform.position - other.gameObject.transform.position;
        var curDist = diff.sqrMagnitude;
        if (curDist > 5f) return;
        other.gameObject.GetComponent<DeathScript>().Kill();
    }
}
