using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    public float smoothing;

    private void LateUpdate()
    {
        if(player!=null)
        {
            if(transform.position != player.position)
            {
                Vector3 targetPos = player.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    public void SetCameraPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
