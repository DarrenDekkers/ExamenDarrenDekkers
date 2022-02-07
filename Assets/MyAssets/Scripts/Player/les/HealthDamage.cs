using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamage : MonoBehaviour
{
    public float heartHP;
    public int hearts = 2;


    private EnemyDamage enemyDamage;
    public GameObject thePlayer;

    void Start()
    {

        enemyDamage = thePlayer.GetComponent<EnemyDamage>();
    }

    public void Update()
    {
        if (enemyDamage.doingDamage == true)
        {
            heartHP = enemyDamage.health / 30;
            PlayerGUIManager.Gui_Instance.UpdateHeart(heartHP, hearts);
        }
    }




}
