using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePatrol : MonoBehaviour
{
    public Vector3 start, end, dir;
    public float velocity;
    public bool startToEnd;
    void Start()
    {
        transform.position = start;
        dir = (end - start).normalized;
    }
    void Update()
    {
        if (transform.position == start)
            startToEnd = true;
        else
            startToEnd = false;
        if(startToEnd)
        {
            if (transform.position.x < end.x - 0.1)
            {
                transform.position += dir * velocity * Time.deltaTime;
            }
            else if (transform.position.x > end.x + 0.1)
            {
                transform.position -= dir * velocity * Time.deltaTime;
            }
            else
                transform.position = end;
        }
        else
        {
            if (transform.position.x < start.x - 0.1)
            {
                transform.position += -dir * velocity * Time.deltaTime;
            }
            else if (transform.position.x > start.x + 0.1)
            {
                transform.position -= -dir * velocity * Time.deltaTime;
            }
            else
                transform.position = start;
        }
    }
}