using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
[ExecuteInEditMode]
#endif

public class AI_WaypointNavigation : MonoBehaviour
{


    public List<Vector3> wayPointList;

    int oldCount, currentCount;



#if UNITY_EDITOR
    // Start is called before the first frame update
    void Awake()
    {


        wayPointList = new List<Vector3>();
        UpdateWayPoints(ref wayPointList);
        CheckChanges();

    }

    // Update is called once per frame
    void Update()
    {

        UpdateWayPoints(ref wayPointList);

        if (!CheckChanges())
        {
            RenderWayPoints(wayPointList);
        }





    }

    void RenderWayPoints(List<Vector3> getWpList)
    {
        for (int i = 0; i < getWpList.Count; i++)
        {
            getWpList[i] = transform.GetChild(i).position;
            Debug.DrawLine(getWpList[i], getWpList[(i + 1) % getWpList.Count], Color.green);
        }
    }





    public bool CheckChanges()
    {
        currentCount = transform.childCount;
        if (currentCount != oldCount)
        {

            oldCount = currentCount;
            return true;
        }
        else
        {
            oldCount = currentCount;
            return false;
        }

    }




    public void UpdateWayPoints(ref List<Vector3> getWpList)
    {
        if (CheckChanges())
        {
            if (transform.childCount != getWpList.Count)
            {
                getWpList = new List<Vector3>();
            }


            foreach (Transform child in transform)
            {

                AddWaypoint(ref getWpList, child);

            }

        }

    }

    public void ClearAllWayPoints(ref List<Vector3> getWpList)
    {
        getWpList.Clear();
    }

    public void AddWaypoint(ref List<Vector3> getWpList, Transform wp)
    {
        print("added: " + wp.name);
        getWpList.Add(wp.position);
    }

    public void RemoveWaypoint(ref List<Vector3> getWpList, Transform wp)
    {
        print("removed: " + wp.name);
        getWpList.Remove(wp.position);
    }
#endif
}
