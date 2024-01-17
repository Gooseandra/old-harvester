using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "vagatables_value", menuName = "ScriptableObjects/vagatables_value", order = 2)]

public class vagatables_value : ScriptableObject
{
    [SerializeField] int value;
    
    public int getValue() { return value; }
    public void reset() { value = 0; }
    public void addValue() { value += 1; }
    public void take() { value -= 1; }
}
