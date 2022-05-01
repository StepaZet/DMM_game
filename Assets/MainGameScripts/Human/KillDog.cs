using System.Collections;
using System.Collections.Generic;
using MetaScripts;
using UnityEngine;

public class KillDog : MonoBehaviour
{
    public GameObject human;
    public ParticleSystem part;
    
    public void Kill()
    {
        var sc = gameObject.AddComponent<SceneChanger>();
        sc.ChangeScene(5);
    }
}
