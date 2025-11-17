using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    public Vector3 moveAmount = Vector3.zero;
    public float smoothTime = 0.2f;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 velocity = Vector3.zero;
    private bool movingTowardsEndPos = true;

    void Start()
    {
        startPos = transform.position;
        endPos = transform.position + moveAmount;
    }

    void Update()
    {
        if (movingTowardsEndPos)
        {
            transform.position = Vector3.SmoothDamp(transform.position, endPos, ref velocity, smoothTime);
            if ((transform.position - endPos).sqrMagnitude < 0.1f)
            {
                movingTowardsEndPos = false;
            }
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, startPos, ref velocity, smoothTime);
            if ((transform.position - startPos).sqrMagnitude < 0.1f)
            {
                movingTowardsEndPos = true;
            }
        }
    }
}
