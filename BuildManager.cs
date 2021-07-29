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

    

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    public Node selectedNode;

    public NodeUI nodeUI;


    public bool CanBuild { get { return turretToBuild != null; } }//this is called a property and it's called the property because we only allow it to actually get something ,
                                                                  //we only allow ourselves to get something from this variable ,
                                                                  //this variable can never be set and it's pretty much the equivalent of writing a small function
                                                                  //that will just check if turretToBuild is equal to null or is not equal to null and then return the result 
                                                                  //so what we will be doing is we are saying that
                                                                  //we want a public bool variable called can build
                                                                  //and when we try to use that
                                                                  //say if we can build and instantly going to check if turretToBuild is not equal to null
                                                                  //and if it isn't equal to no ,it's going to return true so we can build
                                                                  //and esle it's going to return false so we can't build
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } } // >= return false; < return true;


  
   
    public void SeletedNode(Node node)
    {
        if(selectedNode == node)
        {
            DeslecteNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeslecteNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

 
    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeslecteNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }


}
