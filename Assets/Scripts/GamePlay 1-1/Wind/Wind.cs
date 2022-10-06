using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float continuousTime;
    void Start()
    {
        Invoke(nameof(Destroy), continuousTime);
        //Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.Find("Player").GetComponent<BoxCollider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Windable"))
        {
            Debug.Log("YES");
            collision.SendMessage("BeWinded", SendMessageOptions.DontRequireReceiver);
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
