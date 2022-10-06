using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorOpen : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(false);
    }
}
