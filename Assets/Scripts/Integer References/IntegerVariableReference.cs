using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class IntegerVariableReference
{
    public bool UseConstant;
    public float ConstantValue;
    public IntegerVariable Variable;

    public float Value
    {
        get{ return UseConstant ? ConstantValue : Variable.value; }
        set {Variable.value = value;}
    }

}
