using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_way_obj : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Update()
    {
        transform.position = player.transform.position;
        transform.rotation= player.transform.rotation;
    }

    public GameObject getPlayer() { return player; }
}
