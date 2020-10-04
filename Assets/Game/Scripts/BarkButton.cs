using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkButton : MonoBehaviour
{
    public Sprite spriteOn;
    public Sprite spriteOff;

    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TurnOn()
    {
        _spriteRenderer.sprite = spriteOn;
    }

    public void TurnOff()
    {
        _spriteRenderer.sprite = spriteOff;
    }
}
