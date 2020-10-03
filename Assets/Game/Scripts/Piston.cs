using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public Vector3 direction;

    public float distance;
    public float timeForward;
    public float timeBackward;
    public float coolingTime;
    
    private void Start()
    {
        StartCoroutine(StartPistonCoroutine());
    }

    private IEnumerator StartPistonCoroutine()
    {
        var positionOld = gameObject.transform.position;
        var positionNew = positionOld + direction * distance;

        var sequence = DOTween.Sequence();
        sequence.Append(gameObject.transform.DOMove(positionNew, timeForward));
        sequence.Append(gameObject.transform.DOMove(positionOld, timeBackward));
        yield return sequence.WaitForCompletion();

        yield return new WaitForSeconds(coolingTime);

        StartCoroutine(StartPistonCoroutine());
    }
}
