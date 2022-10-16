using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlForBall : MonoBehaviour
{
    public float walkSpeed;
    public Rigidbody2D rb;
    public GameObject[] balls;
    Transform transform;
    public GameObject wind_prefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }
    void Update()
    {
        Move();

        Blow();
    }
    
    float get_distance2(Vector3 a, Vector3 b)
    {
        float d = (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
        return d;
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
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

            Instantiate(wind_prefab, new Vector3(transform.position.x, transform.position.y + 1.0f , transform.position.z), Quaternion.identity);
        }
    }

}