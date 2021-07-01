using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] waypoints;

    private void Awake()
    {
        waypoints = new Transform[transform.childCount];//計算他的下面有幾個子項目
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);//把每一個waypoints對應到transform底下的子項目，transform的子項目就會依照順序排列數字
                                                 //EX:waypoints[1]=transform.getchild底下的waypoint(GameObject)[1]
            
        }
    }

}
