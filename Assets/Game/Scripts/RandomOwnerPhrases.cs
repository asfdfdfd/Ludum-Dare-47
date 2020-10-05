using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomOwnerPhrases : MonoBehaviour
{
    private AudioSource _audioSource;

    public AudioClip[] phrases;

    public float minRandomTime;
    public float maxRandomRime;
    
    private readonly Random _random = new Random();
    
    private void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(PlayRandomSoundsCoroutine());
    }

    private IEnumerator PlayRandomSoundsCoroutine()
    {
        while (true)
        {
            var waitSeconds = _random.NextDouble() * (maxRandomRime - minRandomTime) + minRandomTime;
            
            yield return new WaitForSeconds(Convert.ToSingle(waitSeconds));

            var randomSound = _random.Next(0, phrases.Length);
            
            _audioSource.PlayOneShot(phrases[randomSound]);
        }
    }
}
