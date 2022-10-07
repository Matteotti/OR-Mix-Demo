using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int tile_max = 108;
    public int tile_count = tile_max;
    public int wall_count = 5;

    public const int enemy_count = 3;
    public GameObject[] enemy;
    public int enemy_remain;
    private bool awake_done;

    enum Status
    {
        Playing,
        Fail,
        Success,
    };
    Status game_status;

    void Start()
    {
        enemy_remain = enemy_count;
        game_status = Status.Playing;
        awake_done = false;
    }

    void Update()
    {
        // Deal with Success and Fail



        // Awake Enemy
        if(!awake_done && wall_count == 0)
        {
            for(int i=0;i< enemy_count; ++i)
                enemy[i].GetComponent<EnemyController>().is_awaked = true;
            awake_done = true;
        }

        if(tile_count < tile_max * 0.4)
        {
            game_status = Status.Fail;
        }

        if(enemy_remain==0 && tile_count == tile_max)
        {
            game_status = Status.Success;
        }
    }
}
