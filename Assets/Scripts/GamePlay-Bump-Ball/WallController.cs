using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    GameManager gameMgr;

    void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameManager>();
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D e)
    {
        if (e.gameObject.tag == "Ball")
        {
            gameObject.SetActive(false);
            gameMgr.wall_count -= 1;
        }
    }
}
