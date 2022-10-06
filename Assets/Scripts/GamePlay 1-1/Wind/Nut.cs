using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void BeWinded()
    {
        Debug.Log("WINDED");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
    }
}