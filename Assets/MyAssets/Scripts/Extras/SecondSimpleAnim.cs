using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class SecondSimpleAnim : MonoBehaviour
{
    public AudioSource soundPlayer;
    public AudioClip clip;

    [SerializeField] GameObject makeActive;
    [SerializeField] GameObject makeActive2;

    [SerializeField] GameObject makeInActive;

    [SerializeField] TMP_Text textSpace;
    [SerializeField] string text;

    SphereCollider sphereCollider;



    void OnTriggerEnter(Collider col)
    {

        if (col.tag != "Player")
        {

            return;
        }
        else
        {

            makeInActive.SetActive(false);

            SphereCollider sphereCollider = transform.GetComponent<SphereCollider>();
            sphereCollider.radius = 9f;

            SetString(textSpace, text);

            if (makeActive != null)
            {
                makeActive.SetActive(true);
            }

            if (makeActive2 != null)
            {
                makeActive2.SetActive(true);
            }



        }

    }

void OnTriggerExit()

{
    SetString(textSpace, null);
}

    void PlayClip(AudioClip clip)
    {
        soundPlayer.PlayOneShot(clip);

    }


    void SetString(TMP_Text setText, string getText)
    {

        setText.SetText(getText);

    }
}
