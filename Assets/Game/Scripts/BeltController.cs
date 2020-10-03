using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltController : MonoBehaviour
{
    public Vector2 direction;

    public float speed;

    private GameObject _spitz;
    private Collider2D _spitzCollider;
    private Rigidbody2D _spitzRigidbody;
    private SpitzController _spitzController;
    
    private Vector2 _movementForce;
    
    private void Start()
    {
        _spitz = GameObject.Find("Spitz");
        _spitzCollider = _spitz.GetComponent<Collider2D>();
        _spitzRigidbody = _spitz.GetComponent<Rigidbody2D>();
        _spitzController = _spitz.GetComponent<SpitzController>();
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (_spitzCollider == other)
        {
            _movementForce = direction * speed;
        }
        else
        {
            var rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.velocity = direction;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_spitzCollider == other)
        {
            _movementForce = new Vector2();
        }
        else
        {
            var rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.velocity = new Vector2();
            }
        }
    }

    private void FixedUpdate()
    {
        _spitzRigidbody.AddForce(_movementForce);
        //_spitzController.SetBeltVelocity(_movementForce);
    }
}
