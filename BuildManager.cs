using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instacnce;
    private GameObject turretToBuild;

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

    private void Start()
    {
        turretToBuild = standardTurretPrefab;//放在unity上面的prefab，賦值進turretBuild；在一開始的時候，turretBulid = unity上面設定的prefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;//返回turretBuild的值 (而這邊的turretBuild = StandardTurretPrfab)
    }




}
