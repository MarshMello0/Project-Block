using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //This script is a 3rd person camera roataion script with mouse smoothing

    #region Public Variables
    //Mouse Sensitiviity is how fast the camera will rotate around the target
    public int mouseSensitivity = 10;
    //target is the transform you want to rotate around
    public Transform target;
    //dstFromTarget is the distance from target to camera
    public float dstFromTarget = 5;
    //This Max  and min distance from the target to the camera
    public int dstMaxFromTarget = 20;
    public int dstMinFromTarget = 5;
    public float cameraZoomSpeed;
    //This is how high and low the camera can go when looking around
    public Vector2 pitchMinMax = new Vector2(-40, 85);
    //This is how much the camera will be smoothed if the want it to be
    public float rotationSmoothTime = .12f;
    #endregion

    #region Privite Variables
    //Yaw and pitch is where the mouse is
    float yaw, pitch;
    //for working out mouse smoothing
    Vector3 rotationSmoothVelcity, currentRotation;

    #endregion

    private void Start()
    {
        //This is just to hide and lock the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            dstFromTarget -= cameraZoomSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            dstFromTarget += cameraZoomSpeed;
        }
    }
    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelcity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;
        //This if is for the zoom in and out function with the scroll wheel
        if (dstFromTarget < dstMinFromTarget)
        {
            dstFromTarget = dstMinFromTarget;
        }
        else if (dstFromTarget > dstMaxFromTarget)
        {
            dstFromTarget = dstMaxFromTarget;
        }
        //This moves then camera to the position around the target
        transform.position = target.position - transform.forward * dstFromTarget;
        RaycastHit hit;
        Vector3 direction = target.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.collider.tag != "Player")
            {
                //Debug.Log("Hit: " + hit.collider.name);
                dstFromTarget--;
            }
        }
            

    }
}