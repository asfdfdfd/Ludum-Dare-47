using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class SpitzController : MonoBehaviour, BeltTarget
{
    public float speed;
    
    private bool _isInteractionsAllowed = true;
    
    private Rigidbody2D _rigidbody;

    private Vector2 _movementDirection;
    
    private List<BeltController> _activeBelts = new List<BeltController>();

    private Animator _animator;

    private int _animationParameterIdDirectionHorizontal;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animationParameterIdDirectionHorizontal = Animator.StringToHash("Direction Horizontal");
        
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isInteractionsAllowed)
        {
            _movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (_movementDirection.x > 0)
            {
                _animator.SetInteger(_animationParameterIdDirectionHorizontal, 1);
            } 
            else if (_movementDirection.x < 0)
            {
                _animator.SetInteger(_animationParameterIdDirectionHorizontal, -1);
            }
            else
            {
                _animator.SetInteger(_animationParameterIdDirectionHorizontal, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isInteractionsAllowed)
        {
            Vector2 beltVelocity = new Vector2();
            if (_activeBelts.Count > 0)
            {
                beltVelocity = _activeBelts[0].GetDirection() * _activeBelts[0].speed;
            }

            _rigidbody.velocity = _movementDirection * speed + beltVelocity;
        }
    }
    
    public void SetIsInteractionsAllowed(bool isInteractionsAllowed)
    {
        _isInteractionsAllowed = isInteractionsAllowed;
            
        _movementDirection = new Vector2();
        _rigidbody.velocity = new Vector2();
    }
    
    public void OnBeltEnter(BeltController belt)
    {
        if (!_activeBelts.Contains(belt))
        {
            _activeBelts.Add(belt);
        }
    }

    public void OnBeltStay(BeltController belt)
    {
        
    }

    public void OnBeltExit(BeltController belt)
    {
        if (_activeBelts.Contains(belt))
        {
            _activeBelts.Remove(belt);
        }
    }

    public void TakeItem(string name)
    {
        GameState.TakeItem(name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var bone = other.gameObject.GetComponent<Bone>();
        if (bone != null)
        {
            Destroy(other.gameObject);
        }
    }
}
