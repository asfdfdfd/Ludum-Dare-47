using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    private static List<string> _takenItems = new List<string>();

    private static int _bones = 0;
    
    public static void TakeItem(string name)
    {
        _takenItems.Add(name);
    }

    public static void TakeBone()
    {
        _bones++;
    }
}
