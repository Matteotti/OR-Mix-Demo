using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueArrow : MonoBehaviour
{
    public bool show;
    public float transparentSpeed;
    public Image arrowRenderer;
    void OnEnable()
    {
        arrowRenderer.color = new Color(arrowRenderer.color.r, arrowRenderer.color.g, arrowRenderer.color.b, 0);
    }
    void Update()
    {
        if (show && arrowRenderer.color.a < 0.99)
        {
            arrowRenderer.color += new Color(0, 0, 0, transparentSpeed * Time.unscaledDeltaTime);
        }
        else if (show)
        {
            arrowRenderer.color = new Color(arrowRenderer.color.r, arrowRenderer.color.g, arrowRenderer.color.b, 1);
            show = false;
        }
        else if (arrowRenderer.color.a > 0.01)
        {
            arrowRenderer.color -= new Color(0, 0, 0, transparentSpeed * Time.unscaledDeltaTime);
        }
        else
        {
            arrowRenderer.color = new Color(arrowRenderer.color.r, arrowRenderer.color.g, arrowRenderer.color.b, 0);
            show = true;
        }
    }
}
