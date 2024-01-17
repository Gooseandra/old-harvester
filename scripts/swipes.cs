using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class swipes : MonoBehaviour
{
    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector3 direction);

    private Vector3 tapPosition;
    private Vector3 upPosition;
    private Vector3 swipeDelta;

    private float deadZone = 150f;

    private bool isSwiping = false;
    private bool isMobile;

    void Start()
    {
        isMobile = Application.isMobilePlatform;
    }

    void Update()
    {
        if (!isMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSwiping = true;
                tapPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                upPosition = Input.mousePosition;
            }
        }
        else
        {
            if(Input.touchCount > 1)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Began) {
                    isSwiping = true;
                    tapPosition = Input.GetTouch(0).position;

                }
            }
        }

        CheckSwipe();
    }

    private void CheckSwipe()
    {
        if (isSwiping)
        {
            if(!isMobile)
            {
                swipeDelta = upPosition - tapPosition;
            }
            else if (Input.touchCount > 0)
            {
                swipeDelta = (Vector3)Input.GetTouch(0).position - tapPosition;
            }
            if (swipeDelta.magnitude > deadZone) {
                if (SwipeEvent!= null)
                {
                    if(Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y)) {
                        SwipeEvent(swipeDelta.x > 0 ? Vector3.right : Vector3.left);
                    }
                    else
                    {
                        SwipeEvent(swipeDelta.y > 0 ? Vector3.forward : Vector3.back);
                    }
                }
            }
        }
    }
}
