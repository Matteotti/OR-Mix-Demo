using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperShowAndHide : MonoBehaviour
{
    public bool show;
    public float down, up, acceleration, initSpeed;
    [SerializeField] private float speed;
    public GameObject panel;
    void Update()
    {
        if (speed != 0)
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (show)
        {
            panel.SetActive(true);
            if (transform.position.y < up)
                speed = initSpeed;
            else if (speed > 0.05)
                speed -= acceleration * Time.deltaTime;
            else
                speed = 0;
        }
        else
        {
            if (transform.position.y > down)
                speed = -initSpeed;
            else if (speed < -0.05)
                speed += acceleration * Time.deltaTime;
            else
            {
                speed = 0;
                panel.SetActive(false);
            }
        }
    }
    public void ButtonClose()
    {
        show = false;
    }
}
