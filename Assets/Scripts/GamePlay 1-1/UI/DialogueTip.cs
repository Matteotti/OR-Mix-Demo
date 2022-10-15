using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTip : MonoBehaviour
{
    public bool show;
    public float transparentSpeed;
    public Image sprite1;
    public TMP_Text sprite2;
    public GameObject NPC;
    void Update()
    {
        if (show && sprite1.color.a < 0.99)
        {
            sprite1.color += new Color(0, 0, 0, transparentSpeed * Time.unscaledDeltaTime);
            sprite2.color += new Color(0, 0, 0, transparentSpeed * Time.unscaledDeltaTime);
        }
        else if (show)
        {
            sprite1.color = new Color(sprite1.color.r, sprite1.color.g, sprite1.color.b, 1);
            sprite2.color = new Color(sprite2.color.r, sprite2.color.g, sprite2.color.b, 1);
        }
        else if (sprite1.color.a > 0.01)
        {
            sprite1.color -= new Color(0, 0, 0, transparentSpeed * Time.unscaledDeltaTime);
            sprite2.color -= new Color(0, 0, 0, transparentSpeed * Time.unscaledDeltaTime);
        }
        else
        {
            sprite1.color = new Color(sprite1.color.r, sprite1.color.g, sprite1.color.b, 0);
            sprite2.color = new Color(sprite2.color.r, sprite2.color.g, sprite2.color.b, 0);
        }
    }
}
