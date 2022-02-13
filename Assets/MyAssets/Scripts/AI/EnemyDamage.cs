using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyDamage : MonoBehaviour
{
    public GameObject playerTarget;


    public int enemyDamage = 1;

    public int health = 50;


    private PlayerLife playerLife;


    





    void Awake()
    {

       

        playerTarget = GameObject.Find("Player");


        playerLife = playerTarget.GetComponent<PlayerLife>();

    }

    void Update()
    {


        //Enemy dies
        if (health <= 0)
        {
            if (gameObject.tag != "Player")
            {

                Die();

            }

        }

    }

    void OnTriggerStay(Collider col)
    {

        if (col.tag == "Player")
        {

            playerLife.PlayerDamage(enemyDamage);

        }

    }


 public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }


}

//get component van speler en deal daar damage