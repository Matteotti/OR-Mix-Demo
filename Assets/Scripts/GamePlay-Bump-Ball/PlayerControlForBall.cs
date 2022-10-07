using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlForBall : MonoBehaviour
{
    public float walkSpeed;
    public Vector3 target;
    public Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal * transform.localScale.x < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        rb.velocity = new Vector2(walkSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical * transform.localScale.y < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        rb.velocity = new Vector2(rb.velocity.x, walkSpeed * Input.GetAxisRaw("Vertical"));

        UpdateAnim();
    }
    

    void UpdateAnim()
    {
        if(rb.velocity.x != 0)
            animator.SetFloat("SpeedX", rb.velocity.x);
        //animator.SetFloat("SpeedY", rb.velocity.y);
    }

}