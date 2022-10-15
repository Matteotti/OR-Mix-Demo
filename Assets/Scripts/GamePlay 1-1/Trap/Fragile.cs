using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragile : MonoBehaviour
{
    public float Time, recoverTime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Invoke("Destroy", Time);
        }
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
        Invoke("Return", recoverTime);
    }
    private void Return()
    {
        gameObject.SetActive(true);
    }
}
