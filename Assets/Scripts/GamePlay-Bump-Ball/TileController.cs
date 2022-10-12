using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    public Sprite good;
    public Sprite bad;
    GameManager gameMgr;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameManager>();
    }


    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D e)
    {
        if (e.tag == "Ball")
        {
            if(m_SpriteRenderer.sprite != good)
            {
                m_SpriteRenderer.sprite = good;
                gameMgr.tile_count++;
            }
        }
        else if(e.tag == "Enemy")
        {
            if (m_SpriteRenderer.sprite != bad)
            {
                m_SpriteRenderer.sprite = bad;
                gameMgr.tile_count--;
            }
        }
    }
}
