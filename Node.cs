using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()//按下滑鼠按鍵時
    {
        if (turret != null)//當不是空的時候，也就是上面有東西時
        {
            Debug.Log("Can't bulid there");
            return;
        }

        //bulid a turret
        GameObject turretToBuild = BuildManager.instacnce.GetTurretToBuild();//新增一個unity上面設置的standardTurretPrefab
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);//turret等於生成一個unity上面設置的standardTurretPrefab

    }




    private void OnMouseEnter()//記得在unity物件上添加collider或是rigibody來觸發事件，否則會沒有反應
                               //當滑鼠座標射線移進物件時
    {
        rend.material.color = hoverColor;
    }


    private void OnMouseExit()//當滑鼠座標射線移開物件時
    {
        rend.material.color = startColor;
    }
}
