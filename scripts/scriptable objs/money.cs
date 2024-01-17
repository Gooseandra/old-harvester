using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "money", menuName = "ScriptableObjects/money", order = 1)]
public class money : ScriptableObject
{
    [SerializeField] int moneyValue;

    public int get() { return moneyValue; }
    public void set(int arg) { moneyValue = arg; }
}
