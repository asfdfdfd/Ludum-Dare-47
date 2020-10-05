using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Timers;
using DG.Tweening;
using UnityEngine;
using Random = System.Random;
using Vector2 = UnityEngine.Vector2;

public class SpitzController : MonoBehaviour
{
    public float speed;
    
    private bool _isInteractionsAllowed = true;
    
    private Rigidbody2D _rigidbody;

    private Vector2 _movementDirection;
    
    private List<BeltController> _activeBelts = new List<BeltController>();

    private Animator _animator;

    private int _animationParameterIdDirectionHorizontal;

    public AudioSource soundTakeBone;
    public AudioSource soundTakeJake;
    public AudioSource soundMeetGoat;

    public AudioSource[] soundsBark;
    
    private Random random = new Random();

    public GameObject gameObjectBarkIcon;

    private static readonly float BARK_ICON_TIMER = 1.0f;

    private float barkIconTimer = 0.0f;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animationParameterIdDirectionHorizontal = Animator.StringToHash("Direction Horizontal");
        
        _rigidbody = GetComponent<Rigidbody2D>();
        
        gameObjectBarkIcon.SetActive(false);
    }

    private void Update()
    {
        if (_isInteractionsAllowed)
        {
            _movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (_movementDirection.x > 0)
            {
                _animator.SetInteger(_animationParameterIdDirectionHorizontal, 1);
            } 
            else if (_movementDirection.x < 0)
            {
                _animator.SetInteger(_animationParameterIdDirectionHorizontal, -1);
            }
            else
            {
                _animator.SetInteger(_animationParameterIdDirectionHorizontal, 0);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Bark();
            }
        }

        if (barkIconTimer > 0)
        {
            gameObjectBarkIcon.SetActive(true);
        }
        else
        {
            gameObjectBarkIcon.SetActive(false);
        }

        if (barkIconTimer > 0)
        {
            barkIconTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (_isInteractionsAllowed)
        {
            Vector2 beltVelocity = new Vector2();
            if (_activeBelts.Count > 0)
            {
                beltVelocity = _activeBelts[0].GetDirection() * _activeBelts[0].speed;
            }

            _rigidbody.velocity = _movementDirection * speed + beltVelocity;
        }
    }
    
    public void SetIsInteractionsAllowed(bool isInteractionsAllowed)
    {
        _isInteractionsAllowed = isInteractionsAllowed;
            
        _movementDirection = new Vector2();
        _rigidbody.velocity = new Vector2();
    }
    
    public void OnBeltEnter(BeltController belt)
    {
        if (!_activeBelts.Contains(belt))
        {
            _activeBelts.Add(belt);
        }
    }
    
    public void OnBeltExit(BeltController belt)
    {
        if (_activeBelts.Contains(belt))
        {
            _activeBelts.Remove(belt);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var bone = other.gameObject.GetComponent<Bone>();
        if (bone != null)
        {
            Destroy(other.gameObject);
            
            TakeBone();
        }

        var jake = other.gameObject.GetComponent<Item>();
        if (jake != null)
        {
            Destroy(other.gameObject);

            TakeJake();
        }

        if (!GameState.IsGoatMet())
        {
            var goat = other.gameObject.GetComponent<Goat>();
            if (goat != null)
            {
                MeetGoat();
            }
        }
    }

    private void TakeBone()
    {
        soundTakeBone.Play();
        
        GameState.TakeBone();
    }

    private void TakeJake()
    {
        soundTakeJake.Play();
        
        GameState.TakeItem();
    }

    private void MeetGoat()
    {
        soundMeetGoat.Play();
        
        GameState.MeetGoat();
    }

    public void Bark()
    {
        barkIconTimer = BARK_ICON_TIMER;

        foreach (var audioSource in soundsBark)
        {
            audioSource.Stop();
        }
        
        if (soundsBark.Length > 0)
        {
            var soundIndex = random.Next(0, soundsBark.Length);
            
            soundsBark[soundIndex].Play();
        }
    }
}
