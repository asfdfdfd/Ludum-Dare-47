using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;

    private GameObject _spitz;
    private Collider2D _spitzCollider;
    private SpitzController _spitzController;
    
    private void Start()
    {
        _spitz = GameObject.Find("Spitz");
        _spitzCollider = _spitz.GetComponent<Collider2D>();
        _spitzController = _spitz.GetComponent<SpitzController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == _spitzCollider)
        {
            _spitzController.TakeItem(name);
            
            Destroy(gameObject);
        }
    }
}
