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
            var objectsAvailableToSwitch = Physics2D.OverlapAreaAll(
                currentPlayableObject.transform.position - SwithcableArea / 2,
                currentPlayableObject.transform.position + SwithcableArea / 2);

            if (objectsAvailableToSwitch.Length != 0)
                if (Input.GetKeyDown(KeyCode.C))
                {
                    foreach (var o in objectsAvailableToSwitch)
                    {
                        var newObject = o.gameObject;
                        if (newObject.layer == 6)
                            currentPlayableObject = newObject.GetComponent<PlayableObject>();
                        Camera.player = currentPlayableObject;
                    }

                }

            currentPlayableObject.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}