
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.instacnce;//讓他再等於回去(重新覆值)，這樣做在SHOP腳本中看見buildManager等同於直接用BuildManager腳本

    }

    //UI 的Botton事件引用
    public void SelecteStandardTurret()//在unity中的UI Botton事件中引用，這邊只是用來在UI上面轉換所選對象
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);//SerTurretToBuild的函式會把standardTurretPrefab的值付給turretToBuild
        //引用BuildManager裡面的SetTurretToBuild函式
        //public GameObject GetTurretToBuild()
        //{
        //    return turretToBuild;//返回turretToBuild的值
        //}

        //public void SetTurretToBuild(GameObject turret)//這邊GameObject 的turret等於standardTurretPrefab
        //{
        //    turretToBuild = turret;
        //}
    }
    public void SelecteAnotherTurret()//在unity中的UI Botton事件中引用，這邊只是用來在UI上面轉換所選對象
    {
        Debug.Log("Another TurretSelected");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }




}
