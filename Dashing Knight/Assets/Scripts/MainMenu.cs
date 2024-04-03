using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class MainMenu : MonoBehaviour
{
    public AudioClip soundClip;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.clip = soundClip;
        audioSource.Play();
    }
}
