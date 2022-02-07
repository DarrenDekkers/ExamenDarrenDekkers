using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    Rigidbody player;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float speed = player.velocity.magnitude;
        // print ("going fast boy:" + speed);
        anim.SetFloat("_moveSpeed", speed);
        Weapon_Inventory getInventory = Weapon_Inventory.inventoryReference;
        if (Input.GetButtonDown("Fire1") && !IsPLaying(anim, "gun_Fire") && getInventory.weaponList[getInventory.currentIndex].current_Ammo > 0)
        {
            anim.SetTrigger("_fireGun");
        }
        if (Input.GetButtonDown("Reload") && !IsPLaying(anim, "gun_Reload"))
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