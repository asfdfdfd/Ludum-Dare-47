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

    private bool _isReverted;

    public Sprite spriteStraightBelt;
    public Sprite spriteStraightBeltArrow;

    public Sprite spriteReverseBelt;
    public Sprite spriteReverseBeltArrow;

    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _spriteRendererArrow;

    public GameObject arrow;
    
    private void Start()
    {
        _spitz = GameObject.Find("Spitz");
        _spitzCollider = _spitz.GetComponent<Collider2D>();
        _spitzRigidbody = _spitz.GetComponent<Rigidbody2D>();
        _spitzController = _spitz.GetComponent<SpitzController>();

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRendererArrow = arrow.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<BeltTarget>()?.OnBeltEnter(this);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_spitzCollider == other)
        {
            _movementForce = direction * speed;
        }

        other.gameObject.GetComponent<BeltTarget>()?.OnBeltStay(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_spitzCollider == other)
        {
            _movementForce = new Vector2();
        }
        
        other.gameObject.GetComponent<BeltTarget>()?.OnBeltExit(this);
    }

    private void FixedUpdate()
    {
        //_spitzRigidbody.AddForce(_movementForce);
        //_spitzController.SetBeltVelocity(_movementForce);
    }

    public void Revert()
    {
        _isReverted = !_isReverted;

        if (_isReverted)
        {
            _spriteRenderer.sprite = spriteReverseBelt;
            _spriteRendererArrow.sprite = spriteReverseBeltArrow;
        }
        else
        {
            _spriteRenderer.sprite = spriteStraightBelt;
            _spriteRendererArrow.sprite = spriteStraightBeltArrow;
        }
    }

    public Vector2 GetDirection()
    {
        if (_isReverted)
        {
            return direction * -1;
        }
        else
        {
            return direction;
        }
    }
}
