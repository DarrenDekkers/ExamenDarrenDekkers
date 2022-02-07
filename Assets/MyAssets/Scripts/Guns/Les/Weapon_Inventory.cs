using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Inventory : MonoBehaviour
{

    public WeaponItem[] weaponList;
    public int currentIndex;

    static public Weapon_Inventory inventoryReference;


    // Start is called before the first frame update
    void Start()
    {
        if (inventoryReference == null)
        {
            //   print ("singleton succes");
            inventoryReference = this;
        }
        else
        {
            //   print ("Double inventory, I destroyed myself.");
            Destroy(gameObject);
        }

    }

    void Update()
    {
        CycleInventory();
    }

    void CycleInventory()
    {
        //met 3 simpele lijnen code kunnen we de functionaliteit maken om door een array of lijst te cyclen.
        float getInput = Input.mouseScrollDelta.y; //detect mousescroll +1 of -1/up of down.
        //float getInput = Input.GetAxis ("CycleInput");
        currentIndex += Mathf.RoundToInt(getInput); //Onze index is een integer, via Mathf ronden we de input af naar een rond getal zodat we geen komma getal over houden.
        currentIndex = currentIndex % weaponList.Length; // Met een modulo operator "%" berekenen we de rest waarden. Wanneer we bij 10 komen is de rest 0. hierdoor kunnen we de index steeds met 1 of -1 optellen.
        //Wanneer de rest 0 is wordt onze cycleIndex dus ook 0 en beginnen we weer van het begin. Later kunnen we het cijfer 10 vervangen met de lengte van onze array. Op deze manier 
        //voorkomen we heel makkelijk een memory overflow. Een overflow komt voor wanneer we een index uit een array willen lezen die niet bestaat.
        currentIndex = currentIndex < 0 ? weaponList.Length - 1 : currentIndex; //wanneer we onder 0 gaan, gaan we terug naar achteraan de lijst.

        // UpdateInventory (weaponList[Mathf.Abs (currentIndex)]);
        UpdateInventory(weaponList[currentIndex]);
    }

    public void WeaponPickup(int index)
    {
        //weaponList[index].weapon.SetActive (true); //haal de singleton op, via daar kunnen we bij onze GameObject array en geven we via een index aan welk object we willen.
        weaponList[index].pickUp = true; //zet onze bool/flag op true wanneer we over een weapon pickup lopen.
        currentIndex = index;
        UpdateInventory(weaponList[currentIndex]);
    }

    void UpdateInventory(WeaponItem currentItem)
    {

        currentItem.weapon.SetActive(true);
        foreach (WeaponItem getWeapon in weaponList)
        {
            if (getWeapon != currentItem || currentItem.pickUp == false)
            {
                getWeapon.weapon.SetActive(false);
            }
        }

    }

}

//We maken een custom classe aan die ons "item" gaat beschrijven, puur met variabelen. Deze plaatsen we boven in een array.
[Serializable]
public class WeaponItem
{
    public GameObject weapon;
    public Transform bulletOrigin;
    public int current_Ammo = 2;
    public int maxAmmo = 10;
    

    public float impactForce = 10f;
    public LayerMask hitMask;

    //Maak een data container aan waar we de verschillende wapenmodussen beschikbaar stellen.
    public enum WeaponType { semiAuto, burstFire, fullAuto }
    public WeaponType currentMode;
    public bool hitScan = true;
    public bool pickUp = false;



}