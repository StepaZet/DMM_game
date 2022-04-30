using System;
using Unity.VisualScripting;
using UnityEngine;

namespace MainGameScripts
{
    public class GameManager : MonoBehaviour
    {
        public PlayableObject currentPlayableObject;
        public CameraController Camera;
        public Vector3 SwithcableArea;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                var objectsAvailableToSwitch = Physics2D.OverlapAreaAll(
                    new Vector2(currentPlayableObject.transform.position.x - SwithcableArea.x / 2,
                        currentPlayableObject.transform.position.y - SwithcableArea.y / 2),
                    new Vector2(currentPlayableObject.transform.position.x + SwithcableArea.x / 2,
                        currentPlayableObject.transform.position.y + SwithcableArea.y / 2));
                
                if (objectsAvailableToSwitch.Length != 0)
                    foreach (var o in objectsAvailableToSwitch)
                    {
                        var newObject = o.gameObject;
                        if (newObject.layer != 6 || newObject.name == currentPlayableObject.name) continue;
                        currentPlayableObject = newObject.GetComponent<PlayableObject>();
                        Camera.player = currentPlayableObject;
                    }
            }


            currentPlayableObject.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}