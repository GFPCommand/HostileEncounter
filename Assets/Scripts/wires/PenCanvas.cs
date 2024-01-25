using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PenCanvas : MonoBehaviour, IPointerClickHandler {

    public Action OnPenCanvasLeftClickEvent;
    public Action OnPenCanvasRightClickEvent;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData) {
        if (eventData.pointerId == -1) {
            OnPenCanvasLeftClickEvent?.Invoke();
        }
        else if (eventData.pointerId == -2) {
            OnPenCanvasRightClickEvent?.Invoke();
        }
    }
}
