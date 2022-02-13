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


    public GameObject spawnLocation;
    public GameObject spawnLocationIsland;

    private EnemySpawner enemySpawner;
    private EnemySpawner enemySpawnerIsland;

    EnemyDamage enemyDamage;
    GameObject[] enemies;



    [SerializeField] GameObject makeInActive;
    [SerializeField] GameObject makeActive;

    void Awake()
    {
        enemySpawner = spawnLocation.GetComponent<EnemySpawner>();
        enemySpawnerIsland = spawnLocationIsland.GetComponent<EnemySpawner>();


    }

    void Update()
    {

        if (playerIn == true && Input.GetKeyDown("e"))
        {

            enemies = GameObject.FindGameObjectsWithTag("Enemy");


            playerController.enabled = false;

            thePlayer.transform.position = teleportTarget.transform.position;

            enemySpawner.onIsland = !enemySpawner.onIsland;
            enemySpawnerIsland.onIsland = !enemySpawnerIsland.onIsland;

            makeInActive.SetActive(false);
            makeActive.SetActive(true);
            foreach (GameObject enemy in enemies)
            {
                enemyDamage = enemy.GetComponent<EnemyDamage>();
                enemyDamage.Die();
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            playerIn = true;
            SetString(textSpace, "Press 'e' to sail away");
        }

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

