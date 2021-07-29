using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButtom;

    public Text sellAmount;

    public Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButtom.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButtom.interactable = false;
        }



        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);

    }

    public void Hide()
    {
        ui.SetActive(false);
    }



    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instacnce.DeslecteNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instacnce.DeslecteNode();
    }

}
