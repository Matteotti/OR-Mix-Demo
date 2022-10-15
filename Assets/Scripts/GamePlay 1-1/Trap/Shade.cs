using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shade : MonoBehaviour
{
    public GameObject boss;
    public bool startCheckGround;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Destroy(GetComponent<Rigidbody2D>());
            GetComponent<BoxCollider2D>().isTrigger = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.SendMessage("CancelKill", SendMessageOptions.DontRequireReceiver);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.SendMessage("InvokeKill", SendMessageOptions.DontRequireReceiver);
        }
    }
}
