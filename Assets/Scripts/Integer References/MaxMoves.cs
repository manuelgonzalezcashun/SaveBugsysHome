using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxMoves : MonoBehaviour
{
    public IntegerVariable maxMoves;
    void Start()
    {
        maxMoves.value = 1;
    }
}
