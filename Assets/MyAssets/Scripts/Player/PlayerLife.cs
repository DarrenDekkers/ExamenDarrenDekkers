using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int playerHealth = 120;
    public int playerCurrentHealth;
    public int healthGoingToGUI;
    public bool doingDamage = false;
    
    EnemyDamage enemyDamageScript;
    public int hearts = 2;
    [SerializeField] GameObject enemy;

    void Awake()
    {
        playerCurrentHealth = playerHealth;
        healthGoingToGUI = playerCurrentHealth / 30;
        enemyDamageScript = enemy.GetComponent<EnemyDamage>();
      
    }


    void Update()
    {

        healthGoingToGUI = playerCurrentHealth / 30;


        if (doingDamage == true)
        {

            PlayerGUIManager.Gui_Instance.UpdateHeart(healthGoingToGUI, hearts);
            doingDamage = false;

        }

        if ((playerCurrentHealth <= 0) && PlayerGUIManager.Gui_Instance.howMuchLife == -2)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            if (playerCurrentHealth <= 0)
            {
                PlayerGUIManager.Gui_Instance.howMuchLife -= 1;
                playerCurrentHealth = playerHealth;
            

            }

        }

    }

    public void PlayerDamage(int enemyDamage)
    {
        playerCurrentHealth -= enemyDamage;
        doingDamage = true;
    }




}
