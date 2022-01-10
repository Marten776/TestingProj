using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public GameObject objectToRotate;
    public bool canRotate = true;
    public float rotationSpeed = 3f;

    Vector3 delta = Vector3.zero;
    Vector3 prev = Vector3.zero;
    void Update()
    {
        if(canRotate) ObjectRotation();
    }

    void ObjectRotation()
    {
        if (Input.GetMouseButton(0) && objectToRotate != null)
        {
            objectToRotate.transform.Rotate(Vector3.up, -Input.GetAxis("Mouse X")* rotationSpeed,Space.World);
            objectToRotate.transform.Rotate(Vector3.left, -Input.GetAxis("Mouse Y") * rotationSpeed, Space.World);
        }

    }
}
