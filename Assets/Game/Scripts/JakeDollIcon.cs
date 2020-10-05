using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JakeDollIcon : MonoBehaviour
{
    public Sprite spriteFound;

    private Image image;

    private bool isSpriteSet = false;
    
    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (!isSpriteSet)
        {
            if (GameState.GetIsItemTaken())
            {
                image.sprite = spriteFound;
                
                isSpriteSet = true;
            }
        }
    }
}
