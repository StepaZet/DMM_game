using System;
using System.Collections;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

namespace MainGameScripts
{
    public class GameManager : MonoBehaviour
    {
        public PlayableObject currentPlayableObject;
        public CameraController Camera;
        public PlayableObject[] Objects;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                var closest = currentPlayableObject;
                var distance = Mathf.Infinity;
                var position = currentPlayableObject.transform.position;
                foreach (var ob in Objects)
                {
                    if (ob.name == currentPlayableObject.name) continue;
                    var diff = ob.transform.position - position;
                    var curDist = diff.sqrMagnitude;
                    if (!(curDist < distance)) continue;
                    closest = ob;
                    distance = curDist;
                }

                Debug.Log(closest.name);
                if (distance < 20f)
                {
                    currentPlayableObject = closest;
                    Camera.player = closest;
                }
            }


            currentPlayableObject.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}