﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToTheNextLevel : MonoBehaviour
{
    public string sceneName;
    public bool isAdditive = false;
    
    private GameObject _spitzGameObject;
    private Collider2D _spitzCollider;
    private SpitzController _spitzController;

    public AudioSource audioSourceEndLevel;
    
    private void Start()
    {
        _spitzGameObject = GameObject.Find("Spitz");
        _spitzCollider = _spitzGameObject.GetComponent<Collider2D>();
        _spitzController = _spitzGameObject.GetComponent<SpitzController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_spitzCollider == other)
        {
            Destroy(GameObject.Find("RandomOwnerPhrases"));
            
            _spitzController.SetIsInteractionsAllowed(false);
            
            StartCoroutine(WinCoroutine(audioSourceEndLevel));
        }
    }

    private IEnumerator WinCoroutine(AudioSource audioSource)
    {
        yield return AudioSourcePlayCoroutine(audioSource);

        if (isAdditive)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);   
        }
    }
    
    private IEnumerator AudioSourcePlayCoroutine(AudioSource audioSource)
    {
        audioSource.Play();

        while (audioSource.isPlaying)
        {
            yield return null;
        }
    }
}
