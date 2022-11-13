using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectController : MonoBehaviour
{
    public float PCRotationSpeed = 10f;
    public float MobileRotationSpeed = 0.4f;
    
    public Camera cam;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * PCRotationSpeed;
        float rotY = Input.GetAxis("Mouse Y") * PCRotationSpeed;

        Vector3 right = Vector3.Cross(cam.transform.up, transform.position - cam.transform.position);
        Vector3 up = Vector3.Cross(transform.position - cam.transform.position, right);
        transform.rotation = Quaternion.AngleAxis(-rotX, up) * transform.rotation;
        transform.rotation = Quaternion.AngleAxis(rotY, right) * transform.rotation;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            OnMouseDrag();
        }
        
        
            // -------------------Code for Zooming Out------------
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (Camera.main.fieldOfView <= 61)
                    Camera.main.fieldOfView += 2;
                if (Camera.main.orthographicSize <= 20)
                    Camera.main.orthographicSize += 0.5f;

            }
            // ---------------Code for Zooming In------------------------
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (Camera.main.fieldOfView > 2)
                    Camera.main.fieldOfView -= 2;
                if (Camera.main.orthographicSize >= 1)
                    Camera.main.orthographicSize -= 0.5f;
            }

            // -------Code to switch camera between Perspective and Orthographic--------
            if (Input.GetKeyUp(KeyCode.B))
            {
                if (Camera.main.orthographic == true)
                    Camera.main.orthographic = false;
                else
                    Camera.main.orthographic = true;
            }
        

    }
}