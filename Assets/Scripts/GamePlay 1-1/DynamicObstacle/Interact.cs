using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool allowDialogue = false, allowAction = false, show;
    public float deltaX, deltaY;
    public Vector3 targetPos;
    public DialogueTip interactTips;
    public GameObject player, tips;
    public PlayerControl playerControl;
    private void Start()
    {
        playerControl = player.GetComponent<PlayerControl>();
    }
    void Update()
    {
        if (allowDialogue)
        {
            tips.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(deltaX, deltaY));
            if (!interactTips.show)
                interactTips.show = true;
            if (Input.GetKeyDown(KeyCode.J))
            {
                playerControl.isFreeze = true;
                playerControl.target = targetPos;
                allowAction = true;
            }
        }
        if (player.transform.position.x == targetPos.x && allowAction)
        {
            if (player.transform.position.x < transform.position.x)
                player.transform.localScale = new Vector3(1, 1, 1);
            else
                player.transform.localScale = new Vector3(-1, 1, 1);
            if (interactTips.show)
                interactTips.show = false;
            if (show)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                this.enabled = false;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            allowDialogue = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            allowDialogue = false;
        if (interactTips.show)
            interactTips.show = false;
    }
}
