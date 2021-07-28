using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;



    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instacnce;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()//按下滑鼠按鍵時
    {
        if (EventSystem.current.IsPointerOverGameObject())//一個場景只能有一個EvnentSystem,current為返回當前的EventSystem；IsPointerOverGameObject檢查是否點擊在UI介面上
            return;//意思是如果點在UI介面上就不執行動作直接return


        if (turret != null)//當不是空的時候，也就是上面有東西時
        {
            buildManager.SeletedNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

      

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("不夠錢購買");
            return;
        }

        PlayerStats.money -= blueprint.cost;


        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("建立turret 花費" + PlayerStats.money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("不夠錢升級");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;

        //Get rid of the old turret
        Destroy(turret);

        //Building a new one
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("升級turret 花費" + PlayerStats.money);

    }

        private void OnMouseEnter()//記得在unity物件上添加collider或是rigibody來觸發事件，否則會沒有反應
                               //當滑鼠座標射線移進物件時
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;//當滑鼠在UI介面上時直接return不執行後續動作(如果有進入if條件內，當第一個return就會直接跳出函式，後面的if不會再執行，所以if的書寫順序很重要)

     

        if (!buildManager.CanBuild)
            return;//沒有對象時直接return不動作(當有兩個if同時成立，且都有return，那會依照書寫順序執行return，即僅執行第一個if條件)

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }


        
    }


    private void OnMouseExit()//當滑鼠座標射線移開物件時
    {
        rend.material.color = startColor;
    }
}
