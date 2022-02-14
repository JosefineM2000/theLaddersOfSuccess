using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_camera : MonoBehaviour
{
    public Transform mainCamera;
    public Transform border;
    public int offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        border.position = mainCamera.position - new Vector3(0, offset, 0);
    }
}
