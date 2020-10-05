using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionTriggerController : MonoBehaviour
{
    private GameObject _spitz;
    private SpitzController _spitzController;
    
    private Collider2D _spitzCollider;

    private bool _isSpitzInTrigger = false;

    public UnityEvent target;

    public UnityEvent eventOnSpitzEnter;
    public UnityEvent eventOnSpitzExit;

    private bool isJumpPressed = false;
    
    private void Start()
    {
        _spitz = GameObject.Find("Spitz");
        _spitzCollider = _spitz.GetComponent<Collider2D>();
        _spitzController = _spitz.GetComponent<SpitzController>();
    }

    private void Update()
    {
        if (!isJumpPressed && _isSpitzInTrigger && Input.GetAxis("Jump") > 0)
        {
            isJumpPressed = true;
            
            target?.Invoke();
        }

        if (Input.GetAxis("Jump") == 0)
        {
            isJumpPressed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_spitzCollider == other)
        {
            _isSpitzInTrigger = true;
            
            eventOnSpitzEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_spitzCollider == other)
        {
            _isSpitzInTrigger = false;
            
            eventOnSpitzExit?.Invoke();
        }
    }
}
