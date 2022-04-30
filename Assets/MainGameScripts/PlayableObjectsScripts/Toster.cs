    using Unity.VisualScripting;
    using UnityEngine;

namespace MainGameScripts.PlayableObjectsScripts
{
    public class Toster : PlayableObject
    {
        private bool isMovementLock;
        public override void Move (Vector2 direction) 
        {
            if (isMovementLock) return;
            GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
            isMovementLock = true;
        }

        private void FixedUpdate()
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                Move(new Vector2(Input.GetAxisRaw("Horizontal")*7, Input.GetAxisRaw("Vertical")*5));
            }
        }
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            isMovementLock = false;
        }
    }
}
