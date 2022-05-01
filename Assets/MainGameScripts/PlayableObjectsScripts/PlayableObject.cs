using MainSceneScripts;
using UnityEngine;

namespace MainGameScripts
{
    public class PlayableObject : MonoBehaviour
    {
        public GameManager gameManager;
        public double BatteryCharge = 5;
        

        protected void Charge()
        {
        
        }

        protected void DeCharge(double delta)
        {
            BatteryCharge -= delta;
        }

        public virtual void Move(Vector2 direction)
        {
            
        }
        
        

    }
}
