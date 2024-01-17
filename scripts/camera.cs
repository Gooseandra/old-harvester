using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}