using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOOMcontroller : MonoBehaviour
{
    public GameObject human;
    public ParticleSystem part;


    public void Kill()
    {
        part.Play();
        human.SetActive(false);
    }
}
