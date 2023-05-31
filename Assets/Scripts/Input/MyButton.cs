using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private bool _buttonPressed;

    public bool ButtonPressed => _buttonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        _buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _buttonPressed = false;
    }
}
