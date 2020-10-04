using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    private static bool _isItemTaken = false;

    private static int _bones = 0;
    
    public static void TakeItem()
    {
        _isItemTaken = true;
    }

    public static void TakeBone()
    {
        _bones++;
    }
}
