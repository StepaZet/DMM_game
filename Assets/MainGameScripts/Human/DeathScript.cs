using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject human;
    public ParticleSystem part;


    public void Kill()
    {
        part.transform.position = transform.position;
        part.Play();
        human.SetActive(false);
    }
}
