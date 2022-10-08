using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileRock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
            Destroy(collision.otherCollider.gameObject);
        }
    }
}
