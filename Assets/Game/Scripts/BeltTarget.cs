using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BeltTarget : MonoBehaviour
{
    private readonly List<BeltController> _activeBelts = new List<BeltController>();

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_activeBelts.Count > 0)
        {
            _rigidbody.velocity = _activeBelts[0].GetDirection() * _activeBelts[0].speed;
        }
    }

    public void OnBeltEnter(BeltController belt)
    {
        if (!_activeBelts.Contains(belt))
        {
            _activeBelts.Add(belt);
        }
    }
    
    public void OnBeltExit(BeltController belt)
    {
        if (_activeBelts.Contains(belt))
        {
            _activeBelts.Remove(belt);
        }
    }
}
