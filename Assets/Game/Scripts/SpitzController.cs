using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class SpitzController : MonoBehaviour
{
    public float speed;
    
    private bool _isInteractionsAllowed = true;
    
    private Rigidbody2D _rigidbody;

    private Vector2 _movementDirection;

    private Vector2 _beltVelocity;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isInteractionsAllowed)
        {
            _movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        if (_isInteractionsAllowed)
        {
            _rigidbody.velocity = _movementDirection * speed + _beltVelocity;
        }
    }
    
    public void SetIsInteractionsAllowed(bool isInteractionsAllowed)
    {
        _isInteractionsAllowed = isInteractionsAllowed;
            
        _movementDirection = new Vector2();
        _rigidbody.velocity = new Vector2();
    }

    public void SetBeltVelocity(Vector2 beltVelocity)
    {
        _beltVelocity = beltVelocity;
    }
}
