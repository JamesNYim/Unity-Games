using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5;
    private float currentWaitTime;
    public float waitTime = 3;

    public Transform waypoint;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        currentWaitTime = waitTime;
        waypoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint.position, moveSpeed * Time.deltaTime);
        
        // Checking if we reached our destination
        if (Vector2.Distance(transform.position, waypoint.position) < 0.2f) 
        {
            if (currentWaitTime <= 0)
            {
                waypoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                currentWaitTime = waitTime;
            }
            else
            {
                currentWaitTime -= Time.deltaTime;
            }
        }
   }
}
// https://www.youtube.com/watch?v=jvtFUfJ6CP8 movement
// https://youtu.be/RqgsGaMPZTw Transparent window