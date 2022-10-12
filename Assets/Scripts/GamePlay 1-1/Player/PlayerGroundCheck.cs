using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public float deltaX, deltaY, checkDistance;
    public float maxCoyoteJumpTime;
    public PlayerControl playerControl;
    [SerializeField]private float coyoteJumpTimeCounter;
    void Update()
    {
        //Debug.DrawRay(transform.position + new Vector3(deltaX * -transform.localScale.x, deltaY), Vector2.down * checkDistance);
        if (Physics2D.Raycast(transform.position + new Vector3(deltaX * -transform.localScale.x, deltaY), Vector2.down, checkDistance, 1 << 6))
        {
            if (!playerControl.isGrounded)
                playerControl.isGrounded = true;
            if (!playerControl.isRealGrounded)
                playerControl.isRealGrounded = true;
            coyoteJumpTimeCounter = 0;
        }
        else if (coyoteJumpTimeCounter <= maxCoyoteJumpTime)
        {
            coyoteJumpTimeCounter += Time.deltaTime;
            if (playerControl.isRealGrounded)
                playerControl.isRealGrounded = false;
        }
        else
        {
            if (playerControl.isGrounded)
                playerControl.isGrounded = false;
            if (playerControl.isRealGrounded)
                playerControl.isRealGrounded = false;
        }
    }
}
