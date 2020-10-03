using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RevertBelt : MonoBehaviour
{
    public List<BeltController> belts;

    public void Revert()
    {
        foreach (var belt in belts)
        {
            belt.Revert();
        }
    }
}
