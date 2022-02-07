using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipWheel : MonoBehaviour
{

    [SerializeField]
    TMP_Text textSpace;
    public Transform teleportTarget;
    public GameObject thePlayer;
    [SerializeField] bool playerIn = false;
    public CharacterController playerController;
    public bool removeEnemy = false;

    public GameObject spawnLocation;
    public GameObject spawnLocationIsland;

    private EnemySpawner enemySpawner;
    private EnemySpawner enemySpawnerIsland;

    [SerializeField] GameObject killField;



    void Awake()
    {
        enemySpawner = spawnLocation.GetComponent<EnemySpawner>();
        enemySpawnerIsland = spawnLocationIsland.GetComponent<EnemySpawner>();


    }

    void Update()
    {
  /*      if (removeEnemy == true)
        {
            print("kill");
           
            killField.SetActive(true);
            removeEnemy = false;
            
        } */ //Did not work
     
    





        if (playerIn == true && Input.GetKeyDown("e"))
        {

            removeEnemy = true;
            playerController.enabled = false;

            thePlayer.transform.position = teleportTarget.transform.position;

            enemySpawner.onIsland = !enemySpawner.onIsland;
            enemySpawnerIsland.onIsland = !enemySpawnerIsland.onIsland;

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Player")
        {
            return;
        }

        playerIn = true;
        SetString(textSpace, "Press 'e' to sail away");



    }

    void SetString(TMP_Text setText, string getText)
    {

        setText.SetText(getText);

    }

    void OnTriggerExit(Collider col)
    {
        SetString(textSpace, null);
        playerIn = false;
        playerController.enabled = true;
    }
}

