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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform.parent);
        }
    }
}
