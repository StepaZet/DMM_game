using MainSceneScripts;
using UnityEngine;

namespace MainGameScripts
{
    public class PlayableObject : MonoBehaviour
    {
        public GameManager gameManager;
        protected int BatteryCharge = 3;
    
    
        protected void ChangeObject(PlayableObject newObject)
        {
            gameManager.currentPlayableObject = newObject;
        }

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
