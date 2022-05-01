using UnityEngine;

namespace MainGameScripts.PlayableObjectsScripts
{
    public class VacuumCleaner : PlayableObject
    {
        public override void Move (Vector2 direction) 
        {
            if (BatteryCharge <= 0) return;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x, 0), ForceMode2D.Impulse);
            if(direction != Vector2.zero)
                DeCharge(0.005);
        }

    }
}
