using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    void Start()
    {
        
    }

    public Rigidbody2D rb;
    private float thrust = 3.0f;

    void Update()
    {
    }

    void AddForceUp()
    {
        rb.AddForce(transform.up * thrust);
    }

    void AddForceRight()
    {
        rb.AddForce((transform.up + transform.right) / 2.0f * thrust);
    }

    void AddForceLeft()
    {
        rb.AddForce((transform.up - transform.right) / 2.0f * thrust);
    }

}

