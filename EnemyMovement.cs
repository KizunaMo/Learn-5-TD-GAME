using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]//查意思

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    public  Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();

        target = WayPoints.waypoints[0];

    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;//兩個座標相減為距離,前面是目標，後面是起始點(座標相減有方向性)
        //Debug.Log(target.position);//GameObject:waypoint，終點目標
        //Debug.Log(transform.position);//GameObject:Enemy，起始點
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);//移動長度距離，移動方向依據相減的關係決定
                                                                                  //(SPACE.WORLD為世界座標，物件的座標不會根據旋轉做變動)

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();

        }

        enemy.speed = enemy.startSpeed;

    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= WayPoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoints.waypoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}
