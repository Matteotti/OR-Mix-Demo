using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int life_count = 3;
    public bool is_awaked = false;
    Rigidbody2D rb;
    GameManager gameMgr;
    Transform transform;

    Vector2 up;
    Vector2 down;
    Vector2 left;
    Vector2 right;
    float v_scale;
    int current_dir; // 0-down / 1-right / 2-up / 3-left
    Vector3 last_pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameManager>();
        transform = GetComponent<Transform>();
        up = new Vector2(0.0f, 1.0f);
        down = new Vector2(0.0f, -1.0f);
        left = new Vector2(-1.0f, 0.0f);
        right = new Vector2(1.0f, 0.0f);
        v_scale = 1.5f;
        current_dir = 0;
    }

    void Update()
    {
        Move();
    }

    // Move According to some rule
    const int frame_to_check = 10;
    int cnt_frame = frame_to_check;
    void Move()
    {
        if (last_pos == transform.position)
        {
            cnt_frame--;
            if (cnt_frame == 0)
            {
                change_dir();
                cnt_frame = frame_to_check;
            }
        }
        else cnt_frame = frame_to_check;

        
        if (current_dir == 0) rb.velocity = down * v_scale;
        else if (current_dir == 1) rb.velocity = right * v_scale;
        else if (current_dir == 2) rb.velocity = up * v_scale;
        else if (current_dir == 3) rb.velocity = left * v_scale;

        last_pos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D e)
    {
        if (e.gameObject.tag == "Ball")
        {
            life_count--;
            change_dir();
            if (life_count == 0)
            {
                gameObject.SetActive(false);
                gameMgr.enemy_remain -= 1;
            }
        }
        else if (e.gameObject.tag == "Wall")
        {
            current_dir = (current_dir + 2) % 4;
        }
    }

    void change_dir()
    {
        int r = current_dir;
        while (r == current_dir)
        {
            r = Random.Range(0, 4);
        }
        current_dir = r;
    }

}
