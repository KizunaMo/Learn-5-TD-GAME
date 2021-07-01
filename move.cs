using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public bool movement;
    public Rigidbody rb;
    public float YVelocity;
    public float XVelocity;
    public float speed = 600f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            movement = true;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        YVelocity = Input.GetAxisRaw("Vertical");
        XVelocity = Input.GetAxisRaw("Horizontal"); 
        if (movement = true)
        {
            rb.velocity = new Vector3(XVelocity * speed * Time.fixedDeltaTime ,0,YVelocity * speed * Time.fixedDeltaTime);
            
        }
    }
}
