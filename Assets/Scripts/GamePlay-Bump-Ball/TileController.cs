using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    Color green;
    GameManager gameMgr;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //green = new Color(155.0f, 202.0f, 178.0f);
        green = m_SpriteRenderer.color;
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameManager>();
    }


    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D e)
    {
        if (e.tag == "Ball")
        {
            if(m_SpriteRenderer.color != green)
            {
                m_SpriteRenderer.color = green;
                gameMgr.tile_count++;
            }
        }
        else if(e.tag == "Enemy")
        {
            if (m_SpriteRenderer.color != Color.black)
            {
                m_SpriteRenderer.color = Color.black;
                gameMgr.tile_count--;
            }
        }
    }
}
