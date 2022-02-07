using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventHandler : MonoBehaviour
{

    [SerializeField]
    AudioSource weaponAs;

    [SerializeField]
    bool debug = false;

    // Update is called once per frame
    public void PlayClip(AudioClip clip)
    {
        weaponAs.PlayOneShot(clip);


    }

}