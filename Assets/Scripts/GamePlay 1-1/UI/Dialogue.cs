using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [TextArea] public List<string> dialogues;
    public TMP_Text text;
    public bool allowNext, show, willRunOtherThingsWhenFinish;
    public float showDialogueGap, transparentSpeed;
    public GameObject arrow, targetGameobject;
    public string targetName;
    public Image sprite1;
    public TMP_Text sprite2;
    [SerializeField] private string now;
    [SerializeField] private int letterPointer, textPointer = 0;
    void OnEnable()
    {
        text.text = null;
        letterPointer = 0;
        textPointer = 0;
        now = dialogues[textPointer];
        InvokeRepeating(nameof(ShowNextLetters), 0.5f, showDialogueGap);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
        {
            letterPointer = now.Length;
        }
        if (allowNext)
        {
            if (!arrow.activeSelf)
                arrow.SetActive(true);
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
            {
                arrow.SetActive(false);
                allowNext = false;
                if (textPointer >= dialogues.Count - 1)
                {
                    show = false;
                    letterPointer = 0;
                    textPointer = 0;
                }
                else
                {
                    now = dialogues[++textPointer];
                    letterPointer = 0;
                    InvokeRepeating(nameof(ShowNextLetters), 0.2f, showDialogueGap);
                }
            }
        }
        if (show && sprite1.color.a < 0.49)
        {
            sprite1.color += new Color(0, 0, 0, transparentSpeed * Time.unscaledDeltaTime * 0.5f);
            sprite2.color += new Color(0, 0, 0, transparentSpeed * Time.unscaledDeltaTime);
        }
        else if (show)
        {
            sprite1.color = new Color(sprite1.color.r, sprite1.color.g, sprite1.color.b, 0.5f);
            sprite2.color = new Color(sprite2.color.r, sprite2.color.g, sprite2.color.b, 1);
        }
        else if (sprite1.color.a > 0.01)
        {
            sprite1.color -= new Color(0, 0, 0, transparentSpeed * Time.unscaledDeltaTime * 0.5f);
            sprite2.color -= new Color(0, 0, 0, transparentSpeed * Time.unscaledDeltaTime);
        }
        else
        {
            sprite1.color = new Color(sprite1.color.r, sprite1.color.g, sprite1.color.b, 0);
            sprite2.color = new Color(sprite2.color.r, sprite2.color.g, sprite2.color.b, 0);
            gameObject.SetActive(false);
            if(willRunOtherThingsWhenFinish)
            {
                targetGameobject.SendMessage(targetName, SendMessageOptions.DontRequireReceiver);
            }
            willRunOtherThingsWhenFinish = false;
        }
    }
    void ShowNextLetters()
    {
        if (letterPointer < now.Length)
            text.text = now.Substring(0, letterPointer++);
        else
        {
            text.text = now;
            letterPointer = 0;
            CancelInvoke(nameof(ShowNextLetters));
            allowNext = true;
        }
    }
}
