using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5;
    private float currentWaitTime;
    public float waitTime = 3;
    
    public Transform waypoint;
    public Transform[] bounds; 
    private int i;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private int waypointIndex = 0;
    private float currentX = 0;
    private float currentY = 0;

    Vector2 newWaypoint()
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
    void Start()
    {
        currentWaitTime = waitTime;
        
        //waypoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); // Determines where the player goes 
        waypoint.position = new Vector3(currentX, currentY);
    }

    void OnMouseOver()
    {
        waypoint.position = transform.position;
    }

    void OnMouseExit()
    {
        waypoint.position = newWaypoint();
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
                //waypoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); // This gets a new position
                waypoint.position = newWaypoint();
                currentWaitTime = waitTime;
            }
            else
            {
                currentWaitTime -= Time.deltaTime;
            }
        }
   }
}
// https://www.youtube.com/watch?v=8eWbSN2T8TE Movement
// https://youtu.be/RqgsGaMPZTw Transparent window