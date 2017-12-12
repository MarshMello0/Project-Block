using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockJoining : MonoBehaviour
{
    FixedJoint joint;
    bool hasConnected;

    private void Start()
    {
        joint = gameObject.GetComponent<FixedJoint>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != transform.parent.name && hasConnected == false)
        {
            joint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
            hasConnected = true;
        }
    }
}
