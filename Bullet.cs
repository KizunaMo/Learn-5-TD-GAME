using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    

    public float speed = 70f;
    public float explosionRadius = 0f;

    public GameObject bulletImpact;

    public void seek(Transform _target)
    {
        target = _target;
    }



    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;//70*Time.Deltatime 的單位應該爲 秒 / 幀 ，意思變成每秒移動的距離為70f???


        if (dir.magnitude <= distanceThisFrame)//如果dir的座標距離小於每秒70f
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);//朝向

    }


    void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }


        
        Destroy(gameObject);

        //Debug.Log("We hit someting");
    }

    void Explode()
    {
        Collider[] colliders =  Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }




}
