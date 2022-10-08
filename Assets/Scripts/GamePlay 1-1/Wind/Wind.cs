using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float continuousTime;
    public GameObject player;
    public Vector2 dir;
    void Start()
    {
        Invoke(nameof(Destroy), continuousTime);
        player = GameObject.Find("Player");
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Windable"))
        {
            collision.SendMessage("BeWinded", dir, SendMessageOptions.DontRequireReceiver);
        }
        else if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Trap"))
        {
            player.GetComponent<PlayerControl>().Fly();
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
