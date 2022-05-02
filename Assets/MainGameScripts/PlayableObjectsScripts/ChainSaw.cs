using System.Collections;
using System.Collections.Generic;
using MainGameScripts;
using UnityEngine;

public class ChainSaw : PlayableObject
{
    public AudioSource chain;
    public override void Move (Vector2 direction) 
    {
        chain.Play();
        GetComponent<Rigidbody2D>().AddForce(direction*2, ForceMode2D.Impulse);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().WakeUp();
    }

    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.GetComponent<DeathScript>()) return;
        var diff = Mathf.Abs(transform.position.x - other.gameObject.transform.position.x);
        if (diff > 4f) return;      
        other.gameObject.GetComponent<DeathScript>().Kill();
    }
}
