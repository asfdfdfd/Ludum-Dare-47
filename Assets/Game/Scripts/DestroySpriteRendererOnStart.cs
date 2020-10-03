using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpriteRendererOnStart : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>());       
    }
}
