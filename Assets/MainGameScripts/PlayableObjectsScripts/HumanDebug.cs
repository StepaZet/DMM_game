using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameScripts.PlayableObjectsScripts
{

    public class HumanDebug : PlayableObject
    {
        public Rigidbody2D Rb;

        private HumanController controller;

        private void Start()
        {
            controller = this.GetComponent<HumanController>();
        }

        public override void Move(Vector2 direction)
        {
            Rb.velocity = new Vector2(direction.x, 0) * controller.speed;
            if (direction.x != 0)
                controller.EyeDirection = (int) Mathf.Sign(direction.x);
        }
    }
}
