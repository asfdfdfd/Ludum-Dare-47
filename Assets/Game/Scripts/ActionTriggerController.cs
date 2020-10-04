using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionTriggerController : MonoBehaviour
{
    private GameObject _spitz;
    private Collider2D _spitzCollider;

    private bool _isSpitzInTrigger = false;

    public UnityEvent target;
    
    private void Start()
    {
        _spitz = GameObject.Find("Spitz");
        _spitzCollider = _spitz.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (_isSpitzInTrigger && Input.GetKeyUp(KeyCode.Space))
        {
            target?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_spitzCollider == other)
        {
            _isSpitzInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_spitzCollider == other)
        {
            _isSpitzInTrigger = false;
        }
    }
}
