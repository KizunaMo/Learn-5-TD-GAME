using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    public Transform target;
    public Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = 0.5f;

    public LineRenderer lineRenderer;

    public ParticleSystem ImpactEffect;
    public Light ImpactLight;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";


    public Transform partToRotate;
    public float turnSpeed = 30f;
    public Transform firePoint;
    
   

    public bool enemyIn;
    public Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);// 第一個數字是等待多久開始第一次，第二個數字是第二次與之後要等待多久什麼時候重複，
                                                  // 0f直接開始，0.5f之後重複執行UpdateTarget，沒必要讓電腦每偵都執行
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);//建立數列,把每個TAG為enemy的都添進數列裡面
        //for (int i = 0; i < enemies.Length; i++)
        //{
        //    Debug.Log(enemies[i]);
        //}
        float shortestDistance = Mathf.Infinity;//Mathf.Infinity表示正無窮，無限大
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)//取一個東西enemy，這個東西就是上面找到有enemyTag的物件， 在enemies數列中去執行
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);//給他一個距離(兩個座標之間的距離)
                                                                                                 //這邊是掛載對象的座標(砲台)跟enemy物件的座標 
            //Debug.Log(transform.position); 

            if(distanceToEnemy < shortestDistance)//如果兩座標的距離小於無窮大
            {
                //Debug.Log(shortestDistance + "A");//最少未生成enemy物件時，距離為無限大，但當生成第一個enemy物件時，就會小於無限大
                shortestDistance = distanceToEnemy;//那無窮大的距離會等於兩座標的距離
                //Debug.Log(shortestDistance + "B");
                nearestEnemy = enemy;//這時nearestEnemy物件會等於enemy物件，原本是null不存在。
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)//如果項目不是空的，而且距離小於設定的range
        {
            target = nearestEnemy.transform;//target的座標等於nearestEnemy
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
            enemyIn = true;
        }
        else
        {
            target = null;
            enemyIn = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if(target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    ImpactEffect.Stop();
                    ImpactLight.enabled = false;
                }
                    

            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;//1f/1f=1
            }

            fireCountdown -= Time.deltaTime;//0減掉每一秒(-1)
        }
        
       

    }



    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;//距離跟方向，前面放目標，後面放起點，有方向性(起點指向目標)
        Quaternion lookRotation = Quaternion.LookRotation(dir); //quaternion為四元數的應用，猜測是向前方轉向，而這前方的位置就是上一行的距離與方向
                                                                //舉例Quaternion.LookRotation(Vector3 v); 註釋旋轉將物體的z軸正方向旋轉到正對目標位置的方向

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;//用Lerp來實現勻速運動的程式碼；
                                                                                                                        //第三個引數Time.deltaTime * turnSpeed可以用來調整運動時間

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        //Quaternion舉例說明
        //但如果已經知道下一幀要到的地點(position)
        //可以這樣算角度.

        //// 假設那東西的 Transform 叫 "it"
        //// 假設下一幀的 Position 叫 "nextPosition"

        //#1.Vector3 currentPosition = it.transform.position;
        //#2.Vector3 deltaVector = nextPosition - currentPosition;//目標放前面，後面放起點
        //#3.Quaternion deltaRotate = Quaternion.LookRotation(deltaVector, Vector3.up);//將物體的z軸正方向旋轉到正對目標位置的方向
        //#4.
        //#5.it.transform.rotation = deltaRotate;
        //#6.it.transform.rotation = Quaternion.Lerp(it.transform.rotation, deltaRotate, Time.deltaTime);  

        //運算上你要理解三維的坐標 Vector 代表的距離及角度....(line #2)
        //Quaternion 的 LookRotation 用法(line #3) 這個 deltaRotate (四元數) 就代表你這一幀輸入後所需的角度.
        //而這個角度直接套用就是你想要的效果. (line #5)

        //Extra:
        //(line #6) 就是用來柔化這個轉向角的公式/API 永遠只取兩個角度的的一部分來達成.
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);//damageOverTime * Time.deltaTime會傳出一個值給Enemy腳本中的TakeDamage(float amount)
        targetEnemy.Slow(slowAmount);


        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;

            ImpactEffect.Play();
            ImpactLight.enabled = true;
        }
            
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        ImpactEffect.transform.position = target.position + dir.normalized;

        ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);

        

    }

    void Shoot()
    {
        //Debug.Log("Shoot");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.seek(target);
        }

    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);



        if (enemyIn && target != null)
        {
            Vector3 enemy = target.position;
            Gizmos.DrawLine(transform.position, enemy);//畫線對象為距離最進的對象

        }

    }


}
