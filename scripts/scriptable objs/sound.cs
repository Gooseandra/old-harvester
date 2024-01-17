using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sound", menuName = "ScriptableObjects/sound", order = 2)]
public class sound : ScriptableObject
{
    [SerializeField] bool soundOn = true;

    public void soundSwitch() {
        soundOn = !soundOn;
    }
    public bool getSound()
    {
        return soundOn;
    }
}
