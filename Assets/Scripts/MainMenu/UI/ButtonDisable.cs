using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisable : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("IfFirstTime") == 1)
            GetComponent<Button>().interactable = false;
    }
}
