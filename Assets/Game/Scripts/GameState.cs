using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    private static bool _isItemTaken = false;

    private static bool _isGoatMeet = false;
    
    private static int _bones = 0;
    
    public static void TakeItem()
    {
        _isItemTaken = true;
    }

    public static void TakeBone()
    {
        _bones++;
    }

    public static void MeetGoat()
    {
        _isGoatMeet = true;
    }

    public static bool IsGoatMet()
    {
        return _isGoatMeet;
    }

    public static int GetBonesCount()
    {
        return _bones;
    }
}
