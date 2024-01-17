using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_way : MonoBehaviour
{
    //public Transform Pointer;
    Vector3 way;
    Vector3 lastWay;
    [SerializeField] GameObject forwardArrow;
    [SerializeField] GameObject backwardArrow;
    [SerializeField] GameObject leftArrow;
    [SerializeField] GameObject rightArrow;


    void changeArrow()
    {
        removeArrows();
        if (way.x < 0)
        {
            forwardArrow.SetActive(true);
        }
        else if (way.x > 0)
        {
            backwardArrow.SetActive(true);
        }
        else if (way.z > 0)
        {
            rightArrow.SetActive(true);
        }
        else if (way.z < 0)
        {
            leftArrow.SetActive(true);
        }
    }

    void removeArrows()
    {
        forwardArrow.SetActive(false);
        backwardArrow.SetActive(false);
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
    }

    private void Start()
    {
        removeArrows();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "way_show")
        {
            way = other.GetComponent<show_way_obj>().getPlayer().GetComponent<move_tracktor>().GetWay();
            if (lastWay != way)
            {
                changeArrow();
            }
            lastWay = way;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "way_show")
        {
            removeArrows();
        }
    }
}
