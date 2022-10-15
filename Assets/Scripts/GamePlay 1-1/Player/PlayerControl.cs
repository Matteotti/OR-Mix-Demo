using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //¿É¿¼ÂÇ£ºÍÁÀÇÌø+ÌøÔ¾²¹³¥
    //´óÌøÐ¡Ìø µ¥´ÎÌøÔ¾
    public float walkSpeed, jumpSpeed, maxAllowedJumpTime, dialogueForceMoveSpeed, flySpeedX, flySpeedY, maxFlyTime;
    [SerializeField] private float jumpTime = 0f;
    public bool allowLongJump, isGrounded, isRealGrounded, allowStart, isFreeze, isFlying, isPlayingFootStep, isPlayingWind;
    public Vector3 target;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject wind, sceneTransition, lineTip, nowTip;
    public AudioPlayerManager audioManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (!isFreeze && !isFlying)
        {
            if (horizontal * transform.localScale.x < 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(walkSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            LongJump();
            Wind();
        }
        else if (isFlying)
        {
            if (horizontal * transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            if (rb.velocity.y > flySpeedY)
            {
                rb.velocity = new Vector2(flySpeedX * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(flySpeedX * Input.GetAxisRaw("Horizontal"), flySpeedY);
            }
            if (isRealGrounded)
            {
                CancelInvoke(nameof(StopFly));
                StopFly();
            }
        }
        else if (isFreeze)
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
        PlaySoundOfFootStep();
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
        animator.SetBool("IsGrounded", isRealGrounded);
    }
    void Wind()
    {
        Vector2 dir = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (dir.y < 0) dir.x = 0;
        if (dir == Vector2.zero)
        {
            if (nowTip != null)
                Destroy(nowTip);
            return;
        }
        float angle = Mathf.Atan2(dir.y, dir.x);
        if (nowTip == null)
            nowTip = Instantiate(lineTip, transform.position + 1.5f * (Vector3)dir, Quaternion.Euler(0, 0, angle / Mathf.PI * 180));
        else
        {
            nowTip.transform.SetPositionAndRotation(transform.position + 1.5f * (Vector3)dir, Quaternion.Euler(0, 0, angle / Mathf.PI * 180));
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            audioManager.Wind();
            GameObject nowWind = Instantiate(wind, transform.position + 2 * (Vector3)dir, Quaternion.Euler(0, 0, angle / Mathf.PI * 180));
            nowWind.GetComponent<Wind>().dir = dir;
            if (dir != new Vector2(0, -1))
                Invoke(nameof(StopFlySound), 1.5f);
            else
                isPlayingWind = true;
        }
    }
    public void Dead()
    {
        //ËÀÍö¶¯»­
        audioManager.Dead();
        sceneTransition.GetComponent<SceneTransition>().widen = true;
        sceneTransition.GetComponent<SceneTransition>().allowNext = true;
        PlayerPrefs.SetInt("NextScene", 1);
    }
    public void Fly()
    {
        if (!isFlying && !isRealGrounded)
        {
            isFlying = true;
            Invoke(nameof(StopFly), maxFlyTime);
        }
        else if (!isRealGrounded)
        {
            CancelInvoke(nameof(StopFly));
            Invoke(nameof(StopFly), maxFlyTime);
        }
        else
        {
            StopFly();
        }
    }
    public void StopFly()
    {
        isFlying = false;
        if (isPlayingWind)
        {
            isPlayingWind = false;
            StopFlySound();
        }
    }
    void StopFlySound()
    {
        audioManager.StopFly();
    }
    void PlaySoundOfFootStep()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("PlayerRun") && !isPlayingFootStep)
        {
            isPlayingFootStep = true;
            audioManager.FootStep();
        }
        else if(!stateInfo.IsName("PlayerRun") && isPlayingFootStep)
        {
            isPlayingFootStep = false;
            audioManager.StopWalk();
        }
    }
}