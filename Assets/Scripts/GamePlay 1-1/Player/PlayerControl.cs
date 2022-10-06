using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //¿É¿¼ÂÇ£ºÍÁÀÇÌø+ÌøÔ¾²¹³¥
    //´óÌøÐ¡Ìø µ¥´ÎÌøÔ¾
    public float walkSpeed, jumpSpeed, maxAllowedJumpTime, maxFallSpeed, dialogueForceMoveSpeed, windGap;
    [SerializeField] private float jumpTime = 0f, windCounter;
    public bool allowLongJump, isGrounded, isRealGrounded, allowStart, isFreeze;
    public Vector3 target;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject wind;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (!isFreeze)
        {
            if (horizontal * transform.localScale.x < 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(walkSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            LongJump();
            Wind();
        }
        else
        {
            if (target.x > transform.position.x + 0.1)
            {
                transform.localScale = new Vector3(1, 1, 1);
                rb.velocity = new Vector2(dialogueForceMoveSpeed, rb.velocity.y);
            }
            else if (target.x < transform.position.x - 0.1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rb.velocity = new Vector2(-dialogueForceMoveSpeed, rb.velocity.y);
            }
            else
            {
                isFreeze = false;
                transform.position = target;
            }
        }
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
    void Wind()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector2 dir = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            float angle = Mathf.Atan2(dir.y, dir.x);
            Instantiate(wind, transform.position + (Vector3)dir, Quaternion.Euler(0, 0, angle / Mathf.PI * 180));
        }
    }
}