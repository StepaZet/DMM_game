using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameScripts.PlayableObjectsScripts
{

    public class HumanDebug : PlayableObject
    {
        public Rigidbody2D Rb;
        private float speed = 5f;

        public override void Move(Vector2 direction)
        {
            Rb.velocity = new Vector2(direction.x, 0) * speed;
        }
    }
}
