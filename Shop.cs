
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;


    BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.instacnce;//讓他再等於回去(重新覆值)，這樣做在SHOP腳本中看見buildManager等同於直接用BuildManager腳本

    }

    

    public void SelecteStandardTurret()//在unity中的UI Botton事件中引用，這邊只是用來在UI上面轉換所選對象
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);

    }
    public void SelecteMissileLauncherTurret()//在unity中的UI Botton事件中引用，這邊只是用來在UI上面轉換所選對象
    {
        Debug.Log("MissileLauncher TurretSelected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
