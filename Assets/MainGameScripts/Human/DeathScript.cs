using System.Collections;
using System.Collections.Generic;
using MetaScripts;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject human;
    public ParticleSystem part;


    public void Kill()
    {
        switch (human.gameObject.name)
        {
            case "Dog":
            {
                var sc = gameObject.AddComponent<SceneChanger>();
                sc.ChangeScene(5);
                break;
            }
            case "Litthe man":
            {
                var sc = gameObject.AddComponent<SceneChanger>();
                sc.ChangeScene(4);
                break;
            }
            default:
            {
                part.transform.position = transform.position;
                part.Play();
                human.SetActive(false);
                break;
            }
        }
    }
}