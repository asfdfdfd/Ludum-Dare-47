using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private GameObject _gameObjectGate1;
    private Collider2D _gameObjectGate1Collider;
    
    private GameObject _gameObjectGate2;
    private Collider2D _gameObjectGate2Collider;

    private bool _isOpened = false;
        
    private void Start()
    {
        _gameObjectGate1 = GameObject.Find("Gate_01");
        _gameObjectGate1Collider = _gameObjectGate1.GetComponent<Collider2D>();
        
        _gameObjectGate2 = GameObject.Find("Gate_02");
        _gameObjectGate2Collider = _gameObjectGate2.GetComponent<Collider2D>();
    }

    public void Open()
    {
        if (!_isOpened)
        {
            _isOpened = true;
            
            Destroy(_gameObjectGate1Collider);
            Destroy(_gameObjectGate2Collider);

            var gameObject1PositionStart = _gameObjectGate1.transform.position;
            var gameObject1PositionEnd = gameObject1PositionStart - _gameObjectGate1.transform.up * 0.5f;
            _gameObjectGate1.transform.DOMove(gameObject1PositionEnd, 0.3f);
            
            var gameObject2PositionStart = _gameObjectGate2.transform.position;
            var gameObject2PositionEnd = gameObject2PositionStart + _gameObjectGate2.transform.up * 0.5f;
            _gameObjectGate2.transform.DOMove(gameObject2PositionEnd, 0.3f);
        }
    }
}
