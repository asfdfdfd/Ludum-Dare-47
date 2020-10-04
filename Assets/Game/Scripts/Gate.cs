using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject gameObjectGate1;
    private Collider2D _gameObjectGate1Collider;
    
    public GameObject gameObjectGate2;
    private Collider2D _gameObjectGate2Collider;

    private bool _isOpened = false;
        
    private void Start()
    {
        _gameObjectGate1Collider = gameObjectGate1.GetComponent<Collider2D>();
        _gameObjectGate2Collider = gameObjectGate2.GetComponent<Collider2D>();
    }

    public void Open()
    {
        if (!_isOpened)
        {
            _isOpened = true;
            
            Destroy(_gameObjectGate1Collider);
            Destroy(_gameObjectGate2Collider);

            var gameObject1PositionStart = gameObjectGate1.transform.position;
            var gameObject1PositionEnd = gameObject1PositionStart - gameObjectGate1.transform.up * 0.5f;
            gameObjectGate1.transform.DOMove(gameObject1PositionEnd, 0.3f);
            
            var gameObject2PositionStart = gameObjectGate2.transform.position;
            var gameObject2PositionEnd = gameObject2PositionStart + gameObjectGate2.transform.up * 0.5f;
            gameObjectGate2.transform.DOMove(gameObject2PositionEnd, 0.3f);
        }
    }
}
