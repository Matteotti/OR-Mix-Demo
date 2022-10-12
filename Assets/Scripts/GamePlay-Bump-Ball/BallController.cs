using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    void Start()
    {
        
    }

    public Rigidbody2D rb;
    private float thrust = 80.0f;

    void Update()
    {
    }

    public void AddForceUp()
    {
        rb.AddForce(transform.up * thrust);
    }

    public void AddForceRight()
    {
        rb.AddForce((transform.up + transform.right) / 2.0f * thrust);
    }

    public void AddForceLeft()
    {
        rb.AddForce((transform.up - transform.right) / 2.0f * thrust);
    }

}

