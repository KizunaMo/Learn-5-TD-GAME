using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instacnce;

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
    public GameObject missileLauncherPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("不夠錢購買");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;


        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("建立turret 花費" + PlayerStats.money);

    }
   

 
    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }


}
