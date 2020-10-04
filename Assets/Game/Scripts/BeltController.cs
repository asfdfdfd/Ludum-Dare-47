using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltController : MonoBehaviour
{
    public bool isCorner;
    
    public Vector2 direction;

    public float speed;

    private GameObject _spitz;
    private SpitzController _spitzController;
    private Collider2D _spitzCollider;
    
    public bool isReverted;

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
        _spitzController = _spitz.GetComponent<SpitzController>();
        _spitzCollider = _spitz.GetComponent<Collider2D>();
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (arrow != null)
        {
            _spriteRendererArrow = arrow.GetComponent<SpriteRenderer>();
        }
        
        SetupSprites();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == _spitzCollider)
        {
            _spitzController.OnBeltEnter(this);
        }
        else
        {
            other.gameObject.GetComponent<BeltTarget>()?.OnBeltEnter(this);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == _spitzCollider)
        {
            _spitzController.OnBeltExit(this);
        }
        else
        {
            other.gameObject.GetComponent<BeltTarget>()?.OnBeltExit(this);
        }
    }

    public void Revert()
    {
        isReverted = !isReverted;

        SetupSprites();
    }

    private void SetupSprites()
    {
        if (isReverted)
        {
            _spriteRenderer.sprite = spriteReverseBelt;
            if (_spriteRendererArrow != null)
            {
                _spriteRendererArrow.sprite = spriteReverseBeltArrow;
            }
        }
        else
        {
            _spriteRenderer.sprite = spriteStraightBelt;
            if (_spriteRendererArrow != null)
            {
                _spriteRendererArrow.sprite = spriteStraightBeltArrow;
            }
        }
    }

    public Vector2 GetDirection()
    {
        //var direction = gameObject.transform.right;
        
        if (isReverted)
        {
            if (!isCorner)
            {
                return direction * -1;
            }
            else
            {
                // Right Top.
                if (direction.x == -1 && direction.y == 0)
                {
                    return new Vector2(0, -1);
                }
                // Left Top.
                else if (direction.x == 0 && direction.y == -1)
                {
                    return new Vector2(1, 0);
                }
                // Left Bottom.
                else if (direction.x == 1 && direction.y == 0)
                {
                    return new Vector2(0, 1);
                }
                // Right Bottom.
                else if (direction.x == 0 && direction.y == 1)
                {
                    return new Vector2(-1, 0);
                }

                throw new Exception("Wrong direction.");
            }
        }
        else
        {
            return direction;
            /*
            if (!isCorner)
            {
                return direction;
            }
            else
            {
                return direction * -1;
            }
            */
        }
    }
}
