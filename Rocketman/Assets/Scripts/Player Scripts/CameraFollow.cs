using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frames
    void Update()
    {
        transform.position = player.position + offset;
    }
}
