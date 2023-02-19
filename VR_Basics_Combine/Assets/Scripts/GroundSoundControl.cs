using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSoundControl : MonoBehaviour
{
    public AudioSource softThud;
    public AudioSource loudThud;
    public AudioSource blam;
    public AudioSource crash;

  


    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("softThud"))
        {
            softThud.Play();
        }
        if (other.gameObject.CompareTag("loudThud"))
        {
            loudThud.Play();
        }
        if (other.gameObject.CompareTag("blam"))
        {
            blam.Play();
        }
        if (other.gameObject.CompareTag("crash"))
        {
            crash.Play();
        }
    }
}
