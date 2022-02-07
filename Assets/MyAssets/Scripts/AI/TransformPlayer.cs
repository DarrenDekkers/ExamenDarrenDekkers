using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayer : MonoBehaviour
{

[SerializeField] Transform playerPlace;



    void Update()
    {
      transform.position  = playerPlace.position ;
      
    }
}
