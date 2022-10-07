using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int life_count = 3;
    public bool is_awaked = false;
    GameManager gameMgr;

    void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameManager>();
    }

    void Update()
    {
        if(is_awaked)
        {
            Move();
        }
    }

    void Move()
    {
        // Move According to some rule
    }

    void OnCollisionEnter2D(Collision2D e)
    {
        if (e.gameObject.tag == "Ball")
        {
            life_count--;
            if(life_count == 0)
            {
                gameObject.SetActive(false);
                gameMgr.enemy_remain -= 1;
            }
        }
    }




}
