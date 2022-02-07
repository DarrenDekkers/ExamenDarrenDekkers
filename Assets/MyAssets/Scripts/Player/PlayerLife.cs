using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
  public int playerHealth = 120;
  public int playerCurrentHealth;

  void Awake()
  {
      playerCurrentHealth = playerHealth;
  }
    
  
}
