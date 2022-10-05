using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //可考虑：土狼跳+跳跃补偿
    //大跳小跳 单次跳跃
    public float walkSpeed, jumpSpeed, maxAllowedJumpTime, maxFallSpeed;
    [SerializeField] private float jumpTime = 0f;
    public bool allowLongJump, isGrounded, isRealGrounded, allowStart;
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
        LongJump();
        UpdateAnim();
    }
    void LongJump()
    {
        if (isRealGrounded && rb.velocity.y < 0.1) allowStart = true;
        if (Input.GetButtonDown("Jump") && isGrounded && allowStart)
        {
            allowLongJump = true;
            allowStart = false;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            allowLongJump = false;
            jumpTime = 0;
        }
        if (Input.GetButton("Jump") && allowLongJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jumpTime += Time.deltaTime;
        }
        if (jumpTime >= maxAllowedJumpTime)
        {
            allowLongJump = false;
            jumpTime = 0;
        }
    }
    void UpdateAnim()
    {
        animator.SetFloat("SpeedX", rb.velocity.x);
        animator.SetFloat("SpeedY", rb.velocity.y);
    }
}