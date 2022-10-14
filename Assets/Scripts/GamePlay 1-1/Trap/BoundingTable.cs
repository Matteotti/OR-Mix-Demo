using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingTable : MonoBehaviour
{
    public float BounceSpeed;
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = BounceSpeed * transform.up;
            animator.SetTrigger("JumpOn");
        }
    }
}
