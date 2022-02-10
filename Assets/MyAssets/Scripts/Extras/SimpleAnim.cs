using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class SimpleAnim : MonoBehaviour
{
    public AudioSource soundPlayer;
    public AudioClip clip;
    Animator anim;
    [SerializeField] GameObject makeActive;
    [SerializeField] GameObject makeActive2;

    [SerializeField] GameObject makeInActive;

    [SerializeField] TMP_Text textSpace;
    [SerializeField] string text;

    Collider skullCol;

    void Start()
    {
        skullCol = GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (soundPlayer.isPlaying)
        {
            textSpace.SetText(text);
        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.tag != "Player")
        {

            return;
        }
        else
        {

            makeInActive.SetActive(false);


            anim.SetTrigger("_skull");

            SetString(text);

            if (makeActive != null)
            {
                makeActive.SetActive(true);
            }

            if (makeActive2 != null)
            {
                makeActive2.SetActive(true);
            }

            skullCol.enabled = false;

        }

    }



    void PlayClip(AudioClip clip)
    {
        soundPlayer.PlayOneShot(clip);

    }

    void SetString(string textInput)
    {

        text = textInput;


    }

    void DeleteText()
    {
        text = null;
    }


}
