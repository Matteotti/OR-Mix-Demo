 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject ball;
    public float speed, timeGap;
    private void Start()
    {
        InvokeRepeating(nameof(CreateBall), 1, timeGap);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
        }
    }
    void CreateBall()
    {
        GameObject nowBall = Instantiate(ball, transform.position - new Vector3(0.8f, 0, 0), Quaternion.identity);
        nowBall.GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0);
    }
}
