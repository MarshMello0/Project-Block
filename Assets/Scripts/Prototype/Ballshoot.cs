using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballshoot : MonoBehaviour
{

    public Transform ballTra;
    public Rigidbody ballRb;
    public Transform spawnTra;
    public int speed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballTra.position = spawnTra.position;
            ballRb.AddRelativeForce(Vector3.forward * speed);
        }
    }
}
