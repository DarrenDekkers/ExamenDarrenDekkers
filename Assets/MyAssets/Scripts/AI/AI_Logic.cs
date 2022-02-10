using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AI_Logic : MonoBehaviour
{




    [SerializeField] NavMeshAgent getAgent;

    [SerializeField] AI_WaypointNavigation getNavigationInfo;



    [SerializeField]
    int startIndex = 0;
    int currentIndex = 0;
    [SerializeField]
    float distanceToWaypoint = 0.1f;

    [SerializeField] GameObject player;
    Transform playerT;


    [SerializeField] Collider col;



    // Start is called before the first frame update
    void Awake()
    {

        getNavigationInfo = FindObjectOfType<AI_WaypointNavigation>();
        player = GameObject.Find("Player");
        playerT = player.transform;


        getAgent = GetComponent<NavMeshAgent>();


        getAgent.SetDestination(getNavigationInfo.wayPointList[startIndex]);
        currentIndex = startIndex;

    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        if (col.tag != "Player")
        {

            return;
        }
        else
        {

            transform.LookAt(playerT);

        }
    }
    void Update()
    {

        //getAgent.SetDestination(playerT.position);
        Debug.DrawLine(transform.position, playerT.position, Color.red);





        if (getAgent.remainingDistance <= distanceToWaypoint)
        {


            getAgent.SetDestination(getNavigationInfo.wayPointList[currentIndex]);
        }


    }
}
