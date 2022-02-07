using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyDamage : MonoBehaviour
{
    public GameObject playerTarget;


    public Collider coll;
    [SerializeField] int enemyDamage;



    public bool doingDamage = false;

    public int hearts = 2;

    public int originalHealth = 50;
    public int health;

    public int playerHealthToBeDamaged;
    private PlayerLife playerLife;
    public int healthGoingToGUI;

    public GameObject wheel;
    public GameObject wheelIsland;

    private ShipWheel shipWheel;
    private ShipWheel shipWheelIsland;




    void Awake()
    {


        playerTarget = GameObject.Find("Player");



        health = originalHealth;
        playerLife = playerTarget.GetComponent<PlayerLife>();



        playerHealthToBeDamaged = health;
        healthGoingToGUI = playerHealthToBeDamaged / 30;







    }

    void Update()
    {


        healthGoingToGUI = playerHealthToBeDamaged / 30;

        if (health <= 0)
        {
            if (gameObject.tag != "Player")
            {

                Die();

            }

        }

        if (coll.enabled == false)
        {
            coll.enabled = true;
        }

        if (doingDamage == true)
        {

            PlayerGUIManager.Gui_Instance.UpdateHeart(healthGoingToGUI, hearts);
            doingDamage = false;

        }





    }




    void OnTriggerStay(Collider col)
    {





        if (col.tag != "Player")
        {

            return;
        }
        else
        {

            playerHealthToBeDamaged -= enemyDamage;
            doingDamage = true;

            if ((playerHealthToBeDamaged <= 0) && PlayerGUIManager.Gui_Instance.howMuchLife == -2)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                if (playerHealthToBeDamaged <= 0)
                {
                    PlayerGUIManager.Gui_Instance.howMuchLife -= 1;
                    playerHealthToBeDamaged = playerLife.playerHealth;
                    playerLife.playerCurrentHealth = playerLife.playerHealth;


                }

            }
        }

    }



    void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }


}

//get component van speler en deal daar damage