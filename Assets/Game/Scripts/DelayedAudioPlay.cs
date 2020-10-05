using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedAudioPlay : MonoBehaviour
{
    private AudioSource _audioSource;

    public float delay;
    
    private void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(DelayedPlayCoroutine());
    }

    private IEnumerator DelayedPlayCoroutine()
    {
        yield return new WaitForSeconds(delay);
        
        _audioSource.Play();
    }
}
