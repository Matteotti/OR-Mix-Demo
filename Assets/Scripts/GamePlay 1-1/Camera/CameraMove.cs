using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 target;
    public GameObject player;
    public PlayerControl playerControl;
    public float speed;
    private void Start()
    {
        playerControl = player.GetComponent<PlayerControl>();
    }
    void Update()
    {
        if (Camera.main.transform.position.x < target.x - 0.1)
            Camera.main.transform.Translate(new Vector3(speed * Time.unscaledDeltaTime, 0, 0));
        else if (Camera.main.transform.position.x > target.x + 0.1)
            Camera.main.transform.Translate(new Vector3(-speed * Time.unscaledDeltaTime, 0, 0));
        else
        {
            if (Camera.main.transform.position.x != target.x)
                Camera.main.transform.position = new Vector3(target.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
            if (Camera.main.transform.position.y < target.y - 0.1)
                Camera.main.transform.Translate(new Vector3(0, speed * Time.unscaledDeltaTime, 0));
            else if (Camera.main.transform.position.y > target.y + 0.1)
                Camera.main.transform.Translate(new Vector3(0, -speed * Time.unscaledDeltaTime, 0));
            else
                Camera.main.transform.position = target;
        }
        if (Camera.main.transform.position != target)
        {
            if (!playerControl.isFreeze)
                playerControl.isFreeze = true;
            if (playerControl.target != player.transform.position)
                playerControl.target = player.transform.position;
        }
        else
        {
            if (playerControl.isFreeze)
                playerControl.isFreeze = false;
            enabled = false;
        }
    }
}
