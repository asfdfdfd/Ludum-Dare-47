using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObjectOnActionTrigger : MonoBehaviour
{
    public void OnActionTriggerActivated()
    {
        Destroy(gameObject);
    }
}
