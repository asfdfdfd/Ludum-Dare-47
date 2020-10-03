using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoor : MonoBehaviour
{
    private bool _isActivationAllowed = true;

    public float time;
    
    public void OnActionTriggerActivated()
    {
        if (_isActivationAllowed)
        {
            _isActivationAllowed = false;
            
            StartCoroutine(DoorCoroutine());
        }    
    }

    private IEnumerator DoorCoroutine()
    {
        gameObject.SetActive(false);
        
        yield return new WaitForSeconds(time);
        
        gameObject.SetActive(true);
        
        _isActivationAllowed = true;
    }
}
