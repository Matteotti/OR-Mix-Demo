using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerMover : MonoBehaviour
{
    public int nowStaying;
    public float scaleChangeSpeed, positionChangeSpeed, targetPosY;
    public List<Button> buttons;
    public GameObject left, right;
    private void Start()
    {
        targetPosY = transform.position.y;
    }
    private void Update()
    {
        if (nowStaying != 0)
        {
            targetPosY = buttons[nowStaying - 1].transform.position.y;
            if (left.transform.localScale.x <= 0.095)
            {
                right.transform.localScale += new Vector3(scaleChangeSpeed * Time.unscaledDeltaTime, scaleChangeSpeed * Time.unscaledDeltaTime, 0);
                left.transform.localScale += new Vector3(scaleChangeSpeed * Time.unscaledDeltaTime, scaleChangeSpeed * Time.unscaledDeltaTime, 0);
            }
            else
            {
                right.transform.localScale = Vector3.one * 0.1f;
                left.transform.localScale = Vector3.one * 0.1f;
            }
        }
        else
        {
            if (left.transform.localScale.x >= 0.005)
            {
                right.transform.localScale -= new Vector3(scaleChangeSpeed * Time.unscaledDeltaTime, scaleChangeSpeed * Time.unscaledDeltaTime, 0);
                left.transform.localScale -= new Vector3(scaleChangeSpeed * Time.unscaledDeltaTime, scaleChangeSpeed * Time.unscaledDeltaTime, 0);
            }
            else
            {
                right.transform.localScale = Vector3.zero;
                left.transform.localScale = Vector3.zero;
            }
        }
        if (transform.position.y != targetPosY)
        {
            if (transform.position.y > targetPosY + 1)
                transform.position -= new Vector3(0, positionChangeSpeed * Time.unscaledDeltaTime, 0);
            else if (transform.position.y < targetPosY - 1)
                transform.position += new Vector3(0, positionChangeSpeed * Time.unscaledDeltaTime, 0);
            else
                transform.position = new Vector3(transform.position.x, targetPosY, transform.position.z);
        }
    }
}
