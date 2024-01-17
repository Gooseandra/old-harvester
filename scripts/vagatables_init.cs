using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vagatables_init : MonoBehaviour
{
    [SerializeField] vagatables_value vv;
    void Start()
    {
        vv.addValue();
    }
}
