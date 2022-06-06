using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 Direction;
    public float timer;
    public float deltaTimer;
    public float obstacleSpeed = 2;
    
    // Update is called once per frame
    void Update()
    {
        deltaTimer -= Time.deltaTime;
        if (deltaTimer <= 0)
        {
            deltaTimer = timer;
            obstacleSpeed = -obstacleSpeed;
        }
        transform.Translate(Direction * Time.deltaTime * obstacleSpeed);
    }
}