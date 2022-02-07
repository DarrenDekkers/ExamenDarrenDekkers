using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerGUIManager : MonoBehaviour
{
    [SerializeField] float heartHP;
    [SerializeField]
    GameObject getPlayer;

public int howMuchLife = 0;

    [SerializeField]
    HeartItem[] playerHearts;

    static public PlayerGUIManager Gui_Instance;

      void Start()
  {
        if (Gui_Instance == null)
        {

            Gui_Instance = this;

        }
        else
        {
            DestroyImmediate(gameObject);
        }


    
    }

    void SetString(TMP_Text setText, string getText)
    {

        setText.SetText(getText);

    }

    public void UpdateHeart(float heartHP, int heart)
    {
        SetHeartState(playerHearts[heart + howMuchLife], heartHP) ; /* howMuchLife*/
    }

    void SetHeartState(HeartItem hItem, float heartHP)
    {

        switch (heartHP)
        {
            case 4:
                print("life = full");
                hItem.hpIcons[0].SetActive(true);
                hItem.hpIcons[1].SetActive(false);
                hItem.hpIcons[2].SetActive(false);
                hItem.hpIcons[3].SetActive(false);
                break;

            case 3:
                print("life = 3/4");
                hItem.hpIcons[0].SetActive(false);
                hItem.hpIcons[1].SetActive(true);
                hItem.hpIcons[2].SetActive(false);
                hItem.hpIcons[3].SetActive(false);
                break;

            case 2:
                print("life = 1/2");
                hItem.hpIcons[0].SetActive(false);
                hItem.hpIcons[1].SetActive(false);
                hItem.hpIcons[2].SetActive(true);
                hItem.hpIcons[3].SetActive(false);
                break;

            case 1:
                print("life = 1/4");
                hItem.hpIcons[0].SetActive(false);
                hItem.hpIcons[1].SetActive(false);
                hItem.hpIcons[2].SetActive(false);
                hItem.hpIcons[3].SetActive(true);
                break;

            case 0:
                print("life = 0");
                hItem.heartPrefab.SetActive(false);
                break;
        }

    }
}
[Serializable]
public class HeartItem
{
    public GameObject heartPrefab;
    public GameObject[] hpIcons;
}