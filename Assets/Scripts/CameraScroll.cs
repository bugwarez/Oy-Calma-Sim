using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public Camera cam;
    private float camFov;
    public float zoomSpeed = 35f;

    private float mouseScrollInput;
    void Start()
    {
        camFov = cam.fieldOfView;
    }

   
    void Update()
    {
        mouseScrollInput = Input.GetAxis("Mouse ScrollWheel");
        camFov -= mouseScrollInput * zoomSpeed;
        camFov = Mathf.Clamp(camFov, 25, 65);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, camFov, zoomSpeed);
    }
}
