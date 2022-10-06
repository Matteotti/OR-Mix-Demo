using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStartDialogue : MonoBehaviour
{
    public bool allowDialogue = false, startDialogue = false, willRunOtherThingsWhenFinish;
    public Vector3 targetPos;
    public DialogueTip dialogueTips;
    public GameObject dialogue, player, targetGameobject;
    public string targetName;
    public PlayerControl playerControl;
    private void Start()
    {
        playerControl = player.GetComponent<PlayerControl>();
    }
    void Update()
    {
        if (allowDialogue)
        {
            if (!dialogueTips.show)
                dialogueTips.show = true;
            if (Input.GetKeyDown(KeyCode.J) && !dialogue.activeSelf)
            {
                allowDialogue = false;
                dialogue.GetComponent<Dialogue>().willRunOtherThingsWhenFinish = willRunOtherThingsWhenFinish;
                dialogue.GetComponent<Dialogue>().targetGameobject = targetGameobject;
                dialogue.GetComponent<Dialogue>().targetName = targetName;
                playerControl.isFreeze = true;
                playerControl.target = targetPos;
            }
        }
        else
        {
            if (dialogueTips.show)
                dialogueTips.show = false;
            if (player.transform.position == targetPos)
            {
                if (player.transform.position.x < transform.position.x)
                    player.transform.localScale = new Vector3(1, 1, 1);
                else
                    player.transform.localScale = new Vector3(-1, 1, 1);
                dialogue.SetActive(true);
                dialogue.GetComponent<Dialogue>().show = true;
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
    }
}
