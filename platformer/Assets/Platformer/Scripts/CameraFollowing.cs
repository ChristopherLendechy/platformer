using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform targetObject;

    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position,newPosition,smoothFactor);
    }
}
