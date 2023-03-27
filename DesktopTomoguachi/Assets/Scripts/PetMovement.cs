using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    // Public Variables
    public Transform waypoint;
    public Transform[] bounds; 
    public float moveSpeed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minWait;
    public float maxWait;

    // Private Variables
    private float currentX = 0;
    private float currentY = 0;
    private float currentWaitTime;
    private float waitTime;

    // For when we want to idle the pet
    void idleMovement()
    {
        waypoint.position = transform.position;
    }

    void dragMovement()
    {
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

    }

    // Finding a new waypoint
    Vector2 newWaypoint()
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // On Game start
    void Start()
    {
        waitTime = Random.Range(minWait, maxWait);
        currentWaitTime = waitTime;
        waypoint.position = new Vector3(currentX, currentY);
    }

    // When mouse is over object
    void OnMouseOver()
    {
        idleMovement();
        
        print("Mouse is over");
    }

    
    void OnMouseDrag()
    {
        dragMovement();
        print("Mouse is clicking");
    }

    // When Mouse exits the object
    void OnMouseExit()
    {
        waypoint.position = newWaypoint();
        print("Mouse exit");
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
                waitTime = Random.Range(minWait, maxWait);
                currentWaitTime = waitTime;
            }
            else
            {
                currentWaitTime -= Time.deltaTime;
            }
        }
   }
}