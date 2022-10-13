using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlForBall : MonoBehaviour
{
    public float walkSpeed;
    public Vector3 target;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject[] balls;
    Transform transform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }
    void Update()
    {
        Move();

        Blow();

        UpdateAnim();
    }
    
    float get_distance2(Vector3 a, Vector3 b)
    {
        float d = (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
        return d;
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal * transform.localScale.x < 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        rb.velocity = new Vector2(walkSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);

        if (transform.position.x < -3.0) transform.position = new Vector3(-3.0f, transform.position.y, transform.position.z);
        if (transform.position.x > 3.5) transform.position = new Vector3(3.5f, transform.position.y, transform.position.z);
    }

    void Blow()
    {
        if (Input.GetButtonDown("Jump"))
        {
            foreach (var ball in balls)
            {
                Transform t = ball.GetComponent<Transform>();
                float d = get_distance2(t.position, transform.position);

                if (d < 5.0f)
                {
                    if (Input.GetKey(KeyCode.W)) ball.GetComponent<BallController>().AddForceUp();
                    else if (Input.GetKey(KeyCode.A)) ball.GetComponent<BallController>().AddForceLeft();
                    else if (Input.GetKey(KeyCode.D)) ball.GetComponent<BallController>().AddForceRight();
                }
            }
        }
    }

    void UpdateAnim()
    {
        animator.SetFloat("SpeedX", rb.velocity.x);
    }

}