using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_tracktor : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5;
    Vector3 moveVector;
    Vector3 newMoveVector;
    Vector3 lastVector;
    [SerializeField] bool needToRotate = false;
    Quaternion targetRotation;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        swipes.SwipeEvent += OnSwipe;
        moveVector= Vector3.left * speed;
        newMoveVector = Vector3.left * speed;
        lastVector = moveVector;
    }

    private void OnSwipe(Vector3 direction)
    {
        if (!needToRotate)
        {
            newMoveVector = new Vector3(direction.x, direction.y, direction.z);
            lastVector = new Vector3(-newMoveVector.z, newMoveVector.y, newMoveVector.x) * speed;
        }
    }

    void FixedUpdate()
    {
        rb.velocity= moveVector;
        if (needToRotate)
        {
            targetRotation = Quaternion.LookRotation(newMoveVector, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
            moveVector = lastVector;
            if (Mathf.Abs(transform.rotation.y - targetRotation.y) <= 0.0007f || Mathf.Abs(transform.rotation.y + targetRotation.y) <= 0.0007f)
            {
                needToRotate = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (lastVector != moveVector && other.gameObject.tag == "tile")
        {
            needToRotate = true;
        }
        if (other.gameObject.tag == "fance")
        {
            moveVector = Vector3.zero;
            GetComponent<Animator>().Play("fance_crash");
            GetComponent<pick_up_plants>().endGame("CRASH!");
        }
    }

    public Vector3 GetWay()
    {
        return lastVector;
    }
}
