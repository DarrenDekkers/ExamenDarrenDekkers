using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusketBehavior : MonoBehaviour, WeaponInterface
{
    public Transform bulletOrigin { get; set; }
    int refCurrentAmmo;
    public int currentAmmo { get { return refCurrentAmmo; } set { refCurrentAmmo = value; } }
    public int maxAmmo { get; set; }
    
    public float impactForce { get; set; }
    public bool hitScan { get; set; }
    public LayerMask hitMask { get; set; }


    Weapon_Inventory getInventory;


    void Start()
    {
        InitializeWeaponData();

    }

    void InitializeWeaponData()
    {
        getInventory = Weapon_Inventory.inventoryReference;

        bulletOrigin = getInventory.weaponList[getInventory.currentIndex].bulletOrigin;

        currentAmmo = getInventory.weaponList[getInventory.currentIndex].current_Ammo;
        maxAmmo = getInventory.weaponList[getInventory.currentIndex].maxAmmo;
   
        hitMask = getInventory.weaponList[getInventory.currentIndex].hitMask;

        impactForce = getInventory.weaponList[getInventory.currentIndex].impactForce;
    }

    public void FireBullet()
    {

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(bulletOrigin.position, bulletOrigin.forward, out hit, hitMask))
        {
            if (hit.transform.gameObject.GetComponent<Rigidbody>() != null)
            {
                hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(-hit.normal * impactForce, ForceMode.Impulse);
            }

            Debug.DrawRay(bulletOrigin.position, bulletOrigin.forward * 1000, Color.blue, 10f);

        }


    }
    public void SetAmmoAmount(int removeAmmoAmount)
    {
        refCurrentAmmo += removeAmmoAmount;
        refCurrentAmmo = Mathf.Clamp(refCurrentAmmo, 0, maxAmmo);
        getInventory.weaponList[getInventory.currentIndex].current_Ammo = refCurrentAmmo;
        InitializeWeaponData();


    }

}