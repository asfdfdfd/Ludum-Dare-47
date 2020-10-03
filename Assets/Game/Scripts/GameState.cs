using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    private static List<string> _takenItems = new List<string>();

    public static void TakeItem(string name)
    {
        _takenItems.Add(name);
    }
}
