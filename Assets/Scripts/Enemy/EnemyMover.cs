using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    private float _horizontalSpeed = 1f;
    [SerializeField]
    private float _vertivalSpeed = 2f;

    private Rigidbody2D _rigidbidy;
    private Transform _target;
    private Camera _mainCamera;
    private float _cameraHeight; 

    private void Start()
    {
        _rigidbidy = GetComponent<Rigidbody2D>(); 
        _mainCamera = Camera.main; 
        _cameraHeight = _mainCamera.orthographicSize;

        _target = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            var direction = Mathf.Sign(_target.position.x - transform.position.x);
            _rigidbidy.velocity = new Vector2(direction * _horizontalSpeed, _rigidbidy.velocity.y);
            _rigidbidy.velocity = new Vector2(_rigidbidy.velocity.x, _vertivalSpeed);
            if (transform.position.y > _mainCamera.transform.position.y + _cameraHeight)
            {
                Destroy(gameObject);
            }
        }
    }
}
