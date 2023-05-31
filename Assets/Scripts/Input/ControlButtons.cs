using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlButtons : MonoBehaviour
{
    [SerializeField]
    private Joystick _joystick;
    [SerializeField]
    private MyButton _gas;
    [SerializeField]
    private MyButton _brake;

    public event Action OnForwad;
    public event Action OnBackward;
    public event Action OnStop;

    public Joystick Joystick => _joystick;
    public MyButton Gas => _gas;
    public MyButton Brake => _brake;

    private void FixedUpdate()
    {
        if (_gas.ButtonPressed)
        {
            OnForwad?.Invoke();
        }
        else if (_brake.ButtonPressed)
        {
            OnBackward?.Invoke();
        }
        else 
        {
            OnStop?.Invoke();
        }
    }
}

