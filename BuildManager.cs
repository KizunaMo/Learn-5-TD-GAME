using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instacnce;
    public  GameObject turretToBuild;

    private void Awake()
    {
       if(instacnce != null)
        {
            Debug.LogError("More than one BuildManager in scene! ");
            return;
        }
        instacnce = this;
        
    }

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    //private void Start()
    //{
    //    turretToBuild = standardTurretPrefab;//放在unity上面的prefab，賦值進turretBuild；在一開始的時候，turretBulid = unity上面設定的prefab;
    //}



    public GameObject GetTurretToBuild()//用來建立所選對象
    {
        return turretToBuild;//返回turretToBuild的值
    }

    public void SetTurretToBuild(GameObject turret)//用來選擇所篹對象
    {
        turretToBuild = turret;
    }




}
