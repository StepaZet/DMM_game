using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

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
                var objectsAvailableToSwitch = new Collider2D[10];
                var size = Physics2D.OverlapAreaNonAlloc(new Vector2(
                        currentPlayableObject.transform.position.x - SwithcableArea.x,
                        currentPlayableObject.transform.position.y - SwithcableArea.y), new Vector2(
                        currentPlayableObject.transform.position.x + SwithcableArea.x,
                        currentPlayableObject.transform.position.y + SwithcableArea.y), objectsAvailableToSwitch,
                    LayerMask.GetMask("Playable"));

                if (size != 0)
                    foreach (var o in objectsAvailableToSwitch)
                    {
                        var newObject = o.gameObject;
                        if (newObject.name == currentPlayableObject.name) continue;
                        currentPlayableObject = newObject.GetComponent<PlayableObject>();
                        Camera.player = currentPlayableObject;
                    }
            }


            currentPlayableObject.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}