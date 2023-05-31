using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : Mover
{
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private ControlButtons _inputButtons;

    private Rigidbody2D _rigidbody;
    private float _minSpeed = 1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputButtons.OnForwad += MoveForward;
        _inputButtons.OnBackward += MoveBackward;
        _inputButtons.OnStop += Stop;

    }

    private void FixedUpdate()
    {
        if (_inputButtons == null)
            return;
        MoveSideways();
    }

    public override float GetSpeed()
    {
        return _speed;
    }

    public override void RiseSpeed(float speedUpValue)
    {
        _speed += speedUpValue;
    }

    public override void SpeedDeceleration(float slowdownValue)
    {
        _speed = Mathf.Max(_speed - slowdownValue, _minSpeed);
    }

    private void MoveSideways()
    {
        var horizontalDirection = Vector3.right * _inputButtons.Joystick.Horizontal;
        transform.Translate(horizontalDirection * Time.fixedDeltaTime * _speed);
    }

    public void MoveForward()
    {
        _rigidbody.velocity = transform.up * _speed;
    }

    public void MoveBackward()
    {
        _rigidbody.velocity = -transform.up * _speed;
    }

    private void Stop()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    private void OnDisable()
    {
        _inputButtons.OnForwad -= MoveForward;
        _inputButtons.OnBackward -= MoveBackward;
        _inputButtons.OnStop -= Stop;
    }
}
