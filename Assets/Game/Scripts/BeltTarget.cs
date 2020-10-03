using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BeltTarget
{
    void OnBeltEnter(BeltController belt);
    void OnBeltStay(BeltController belt);
    void OnBeltExit(BeltController belt);
}
