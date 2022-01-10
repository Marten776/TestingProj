using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public Vector3 pointToLookAt;
    Vector3 beginningPoint;
    public float scrollSpeed = 5f;
    private void Start()
    {
        beginningPoint = transform.position;
    }
    void Update()
    {
        transform.LookAt(pointToLookAt);
        CameraZoom();
    }


    void CameraZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0 && Vector3.Distance(transform.position, pointToLookAt) > 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointToLookAt, scrollSpeed);
        }          
        else if(scroll < 0 ) transform.position = Vector3.MoveTowards(transform.position, beginningPoint, scrollSpeed);
    }

    public void ZoomInWithButton()
    {
        if (Vector3.Distance(transform.position, pointToLookAt) > 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointToLookAt, scrollSpeed);
        }
    }

    public void ZoomOutWithButton()
    {
        transform.position = Vector3.MoveTowards(transform.position, beginningPoint, scrollSpeed);
    }

    
}
