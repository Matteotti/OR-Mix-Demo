using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float existTime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
        }
    }
    private void Start()
    {
        Invoke(nameof(Destroy), existTime);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
