using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        sound.Play();
    }
}
