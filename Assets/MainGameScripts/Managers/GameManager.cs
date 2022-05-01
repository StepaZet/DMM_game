using System;
using System.Collections;
using System.Linq;
using System.Threading;
using MetaScripts;
using Microsoft.Unity.VisualStudio.Editor;
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
        public GameObject[] batteries;



        private void ChangeBattery()
        {
            if (currentPlayableObject.BatteryCharge <= 4)
            {
                batteries[3].SetActive(false);
            }
            if (currentPlayableObject.BatteryCharge <= 3)
            {
                batteries[2].SetActive(false);
            }
            if (currentPlayableObject.BatteryCharge <= 2)
            {
                batteries[1].SetActive(false);
            }
            
            if (currentPlayableObject.BatteryCharge <= 0.5)
            {
                batteries[0].SetActive(false);
            }
            
            
            if (currentPlayableObject.BatteryCharge > 4)
            {
                batteries[3].SetActive(true);
            }
            if (currentPlayableObject.BatteryCharge > 3)
            {
                batteries[2].SetActive(true);
            }
            if (currentPlayableObject.BatteryCharge > 2)
            {
                batteries[1].SetActive(true);
            }
            if (currentPlayableObject.BatteryCharge > 0.5)
            {
                batteries[0].SetActive(true);
            }
            
        }
        
        private void Update()
        {
            if (currentPlayableObject.gameObject.transform.position.x > 310)
            {
                var sc = gameObject.AddComponent<SceneChanger>();
                sc.ChangeScene(3);
            }
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

                if (distance < 20f)
                {
                    currentPlayableObject = closest;
                    Camera.player = closest;
                }
            }
            
            ChangeBattery();
            
            currentPlayableObject.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}