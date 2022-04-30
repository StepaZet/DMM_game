    using Unity.VisualScripting;
    using UnityEngine;

namespace MainGameScripts.PlayableObjectsScripts
{
    public class Toster : PlayableObject
    {
        private bool isMovementLock;
        public override void Move (Vector2 direction) 
        {
            if (Input.GetAxisRaw("Vertical") == 0) return;
            if (BatteryCharge == 0) return;
            if (isMovementLock) return;
            isMovementLock = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            isMovementLock = false;
        }
    }
}
