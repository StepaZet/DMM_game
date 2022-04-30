using MainGameScripts;
using UnityEngine;

namespace MainSceneScripts
{
    public class GameManager : MonoBehaviour
    {
        public PlayableObject currentPlayableObject;
        private void FixedUpdate()
        { 
            currentPlayableObject.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}
