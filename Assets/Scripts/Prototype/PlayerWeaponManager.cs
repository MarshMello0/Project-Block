using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public Camera maincamera;
    public int cameraFov,cameraAimFov;
    public GameObject ball;
    public Transform shootPoint;
    public float ballspeed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = (GameObject)Instantiate(ball);
            Transform ballTra = go.transform;
            Rigidbody ballRig = go.GetComponent<Rigidbody>();
            ballTra.position = shootPoint.position;
            ballRig.AddForce(Vector3.forward * ballspeed);

        }
        if (Input.GetMouseButtonDown(1))
        {
            maincamera.fieldOfView = cameraAimFov;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            maincamera.fieldOfView = cameraFov;
        }
    }

}
