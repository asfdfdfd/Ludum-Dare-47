using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoneUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        text.text = GameState.GetBonesCount().ToString();
    }
}
