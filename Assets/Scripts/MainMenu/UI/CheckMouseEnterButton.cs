using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckMouseEnterButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int thisButtonID;
    public PointerMover pointerMover;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GetComponent<Button>().interactable)
            pointerMover.nowStaying = thisButtonID;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerMover.nowStaying = 0;
    }
}
