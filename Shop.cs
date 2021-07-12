
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.instacnce;
    }

    public void SelecteStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    public void SelecteAnotherTurret()
    {
        Debug.Log("Another TurretSelected");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }




}
