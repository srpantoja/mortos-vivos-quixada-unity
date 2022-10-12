using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offSet;
    private void FixedUpdate()
    {
        transform.position = player.position + offSet;
    }
}
