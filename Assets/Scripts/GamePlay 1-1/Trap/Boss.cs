using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player;
    public float invokeTime, blindTime;
    public bool blind;
    void KillPlayer()
    {
        player.SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
    }
    void InvokeKill()
    {
        if (!blind)
            Invoke(nameof(KillPlayer), invokeTime);
    }
    void CancelKill()
    {
        CancelInvoke(nameof(KillPlayer));
    }
    void Recover()
    {
        blind = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            blind = true;
            Invoke(nameof(Recover), blindTime);
            CancelKill();
            Destroy(collision.gameObject);
        }
    }
}
