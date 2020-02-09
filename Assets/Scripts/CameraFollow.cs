using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private bool follow;

    public float minYThreshold = -2.6f;
    public float followSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (target.position.y < (transform.position.y - minYThreshold))
            follow = false;

        if (target.position.y > transform.position.y) follow = true;

        if (follow)
        {

            Vector3 tempPosition = transform.position;
            tempPosition.y = target.position.y;
            transform.position = tempPosition;
        }
    }
}
