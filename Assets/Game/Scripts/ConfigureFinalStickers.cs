using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureFinalStickers : MonoBehaviour
{
    public GameObject stickerJake;
    public GameObject stickerBones;
    public GameObject stickerGoat;

    private void Start()
    {
        if (!GameState.GetIsItemTaken())
        {
            Destroy(stickerJake);
        }

        if (GameState.GetBonesCount() != 100)
        {
            Destroy(stickerBones);
        }

        if (!GameState.IsGoatMet())
        {
            Destroy(stickerGoat);
        }
    }
}
