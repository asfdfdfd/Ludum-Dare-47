using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToTheNextLevel : MonoBehaviour
{
    public string sceneName;

    private GameObject _spitzGameObject;
    private Collider2D _spitzCollider;
    
    private void Start()
    {
        _spitzGameObject = GameObject.Find("Spitz");
        _spitzCollider = _spitzGameObject.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_spitzCollider == other)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
