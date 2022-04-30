using MainSceneScripts;
using UnityEngine;

namespace MainGameScripts
{
    public class PlayableObject : MonoBehaviour
    {
        public GameManager gameManager;
        public int BatteryCharge = 3;
        

        protected void Charge()
        {
        
        }

        protected void DeCharge()
        {
            
        }

        public virtual void Move(Vector2 direction)
        {
            
        }
        
        

    }
}
