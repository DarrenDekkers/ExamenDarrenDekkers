using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound2D : MonoBehaviour
{
    public AudioClip backgroundLoop;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = backgroundLoop;
            audioSource.Play();
            audioSource.loop = true;
        }
    }
}