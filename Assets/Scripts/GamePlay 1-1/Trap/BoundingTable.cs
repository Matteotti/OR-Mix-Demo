using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingTable : MonoBehaviour
{
    public float BounceSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().velocity = BounceSpeed * transform.up;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = BounceSpeed * transform.up;
        }
    }
}
