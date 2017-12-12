using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraGravity : MonoBehaviour
{
    public float gravitySpeed;

    public Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * gravitySpeed);
    }
}
