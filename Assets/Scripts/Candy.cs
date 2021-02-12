using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public CandyType type;
    [NonSerialized]public Vector3 startPosition;
}

public enum CandyType
{
    candy1,
    candy2,
    candy3,
    candy4,
    candy5,
    candy6,
    candy7,
    candy8
            
}
