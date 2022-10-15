using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    public float pushForce;
    public void BeWinded(Vector2 dir)
    {
        GetComponent<Rigidbody2D>().AddForce(dir.normalized * pushForce, ForceMode2D.Impulse);
    }
}