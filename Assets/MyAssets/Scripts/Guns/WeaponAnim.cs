using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnim : MonoBehaviour
{
    Animator anim;
    Gun gun;


    void Start()
    {
        anim = GetComponent<Animator>();
        gun = GetComponent<Gun>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !IsPLaying(anim, "Gun_Shoot") && gun.currentAmmo > 0)
        {
            
            anim.SetTrigger("_shot");
           

        }

        if (Input.GetButtonDown("Reload") && !IsPLaying(anim, "Gun_Reload") && gun.currentAmmo != gun.maxAmmo)
        {
            anim.SetTrigger("_reload");
         
        }
    }

    bool IsPLaying(Animator getAnim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    


}
