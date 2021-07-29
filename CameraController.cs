using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    

    [Header ("panSet")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;

    public float minY = 10f;
    public float maxY = 80f;

    public float screenMinZ = -50f;
    public float screenMaxZ = -15f;
    public float screenMinX = 0f;
    public float screenMaxX = 35f;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }


    
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)//輸入W或是當滑鼠座標Y大於螢幕高度-設定值時
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime,Space.World);//Vector3.forward (0f,0f,1f)
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);//Vector3.forward (0f,0f,1f)
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);//Vector3.forward (0f,0f,1f)
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);//Vector3.forward (0f,0f,1f)
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");//定義一個數值當推移滑鼠滾輪時

        Vector3 pos = transform.position;
        pos.y += scroll * 1000 * scrollSpeed * Time.deltaTime;//*1000是因為float scroll(滑鼠滾輪)的數值會很小
        pos.y = Mathf.Clamp(pos.y, minY, maxY);//限制一個值的大小介於mixY&maxY
        pos.x = Mathf.Clamp(pos.x, screenMinX, screenMaxX);
        pos.z = Mathf.Clamp(pos.z, screenMinZ, screenMaxZ);

        transform.position = pos;//再把pos的值賦值給transform.position  ((前面都做好計算後再丟回給transform))


    }
}
 