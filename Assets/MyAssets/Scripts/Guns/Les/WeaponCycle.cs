using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCycle : MonoBehaviour
{
    [SerializeField]
    int cycleIndex = 0;

    // Update is called once per frame
    void Update ()
    {

        //met 3 simpele lijnen code kunnen we de functionaliteit maken om door een array of lijst te cyclen.

        float getInput = Input.mouseScrollDelta.y; //detect mousescroll +1 of -1/up of down.
        cycleIndex += Mathf.RoundToInt (getInput); //Onze index is een integer, via Mathf ronden we de input af naar een rond getal zodat we geen komma getal over houden.
        cycleIndex = cycleIndex % 10; // Met een modulo operator "%" berekenen we de rest waarden. Wanneer we bij 10 komen is de rest 0. hierdoor kunnen we de index steeds met 1 of -1 optellen.
        //Wanneer de rest 0 is wordt onze cycleIndex dus ook 0 en beginnen we weer van het begin. Later kunnen we het cijfer 10 vervangen met de lengte van onze array. Op deze manier 
        //voorkomen we heel makkelijk een memory overflow. Een overflow komt voor wanneer we een index uit een array willen lezen die niet bestaat.

    }
}