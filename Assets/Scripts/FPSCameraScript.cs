using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraScript : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }


    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.name == "Valvula")
            {
                ValveScript.cursorOver = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<ValveScript>().RotatePipe();
                }
            }
            else
            {
                ValveScript.cursorOver = false;
            }
        }
    }
}