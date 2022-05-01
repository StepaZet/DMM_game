using UnityEngine;

namespace MainGameScripts.PlayableObjectsScripts
{
    public class Toster : PlayableObject
    {
        private bool isMovementLock;
        public override void Move (Vector2 direction) 
        {
            if (Input.GetAxisRaw("Vertical") == 0) return;
            if (BatteryCharge <= 0) return;
            if (isMovementLock) return;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x * 5, direction.y * 7), ForceMode2D.Impulse);
            if(direction != Vector2.zero)
                DeCharge(0.03);
            isMovementLock = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            isMovementLock = false;
        }
    }
}
