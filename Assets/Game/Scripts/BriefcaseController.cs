using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefcaseController : MonoBehaviour, BeltTarget
{
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    
    private List<BeltController> _activeBelts = new List<BeltController>();
    
    private void Awake()
    {
        _collider = gameObject.GetComponent<Collider2D>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        /*
        if (_belt == null)
        {
            Collider2D[] colliders = new Collider2D[1];

            var contactFilter = new ContactFilter2D();
            contactFilter.layerMask = LayerMask.GetMask("Belt");

            int overlappedCount = _collider.OverlapCollider(new ContactFilter2D(), colliders);

            if (overlappedCount > 0)
            {
                _belt = colliders[0].gameObject.GetComponent<BeltController>();
            }
        }
        */
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
}
