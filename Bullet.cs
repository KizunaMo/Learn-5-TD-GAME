﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;

    public float speed = 70f;

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
        float distanceThisFrame = speed * Time.deltaTime;


        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
    }


    void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(bulletImpact, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(target.gameObject);

        Debug.Log("We hit someting");
    }
}
