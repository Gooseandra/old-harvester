using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_on_scene : MonoBehaviour
{
    [SerializeField] sound s;
    [SerializeField] AudioSource[] audios;
    void Start()
    {
        if (s.getSound())
        {
            foreach (AudioSource audio in audios)
            {
                audio.volume = 1;
            }
        }
        else
        {
            foreach (AudioSource audio in audios)
            {
                audio.volume = 0;
            }
        }
    }
}
