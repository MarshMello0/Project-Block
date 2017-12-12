using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSleep : MonoBehaviour
{

    Rigidbody blocksRB;
    Transform blocksTra;
    Transform playersTra;
    float distance;

    private void Update()
    {
        distance = Vector3.Distance(playersTra.position , blocksTra.position);
        
        if (distance > 10)
        {
            blocksRB.isKinematic = true;
        }
        else
        {
            blocksRB.isKinematic = false;
        }
    }
}
