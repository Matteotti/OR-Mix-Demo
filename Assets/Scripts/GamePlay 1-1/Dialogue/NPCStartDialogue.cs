using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStartDialogue : MonoBehaviour
{
    public bool allowDialogue = false, startDialogue = false;
    public DialogueTip dialogueTips;
    public GameObject dialogue;
    void Update()
    {
        if (allowDialogue)
        {
            if (!dialogueTips.show)
                dialogueTips.show = true;
            if(Input.GetKeyDown(KeyCode.J) && !dialogue.activeSelf)
            {
                dialogue.SetActive(true);
                dialogue.GetComponent<Dialogue>().show = true;
            }
        }
        else
        {
            if (dialogueTips.show)
                dialogueTips.show = false;
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
