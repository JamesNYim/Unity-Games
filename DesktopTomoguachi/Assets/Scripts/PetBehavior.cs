using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBehavior : MonoBehaviour
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

    public Dictionary<string, bool> petStatus = new Dictionary<string, bool>();
    
    // Creating the status dictionary
    private void createStatusDict(Dictionary<string, bool> dict)
    {
        dict.Add("Wandering", false);
        dict.Add("Idle", false);
        dict.Add("Interacting", false);
        dict.Add("Offscreen", false);
        dict.Add("Bothering", false);
        dict.Add("Dragging", false);
    }
   
    // Getting current behavior of pet
    public string getStatus()
    {
        foreach(KeyValuePair<string, bool> status in petStatus)
        {
            if (status.Value)
            {
                return status.Key;
            }
        }
        return null;
    }

    // Setting the status of the pet
    public void setStatus(string status)
    {
        // If there is a status already
        if (getStatus() != null)
        {
            clearStatus(getStatus());
        }
        
        // Setting the status
        petStatus[status] = true;
        print("Set: " + status + " to " + petStatus[status]);
    }

    // Clearing a status of the pet
    public void clearStatus(string status)
    {
        petStatus[status] = false;
    }
    // For when the pet is wandering
    private void wanderMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint.position, moveSpeed * Time.deltaTime);

        // Checking if we reached our destination
        if (Vector2.Distance(transform.position, waypoint.position) < 0.2f) 
        {
            if (currentWaitTime <= 0)
            {
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
    // For when we want to idle the pet
    private void idleMovement()
    {
        waypoint.position = transform.position;
    }

    // For when we are draging the pet
    private void dragMovement()
    {
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    private void botherMovement()
    {
        waypoint.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, waypoint.position, moveSpeed * Time.deltaTime);
    }

    // Finding a new waypoint
    private Vector2 newWaypoint()
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // On Game start
    void Start()
    {
        createStatusDict(petStatus); // Initalizing the pet status dictionary 
        
        waitTime = Random.Range(minWait, maxWait); // Setting wait time for wandering
        currentWaitTime = waitTime;
        
        waypoint.position = newWaypoint();
        setStatus("Wandering"); // Start of wandering
    }

    // When mouse is over object
    void OnMouseOver()
    {
        setStatus("Idle");
    }

    // When Mouse exits the object
    void OnMouseExit()
    {
        setStatus("Wandering");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // Wandering behavior
        if (getStatus() == "Wandering")
        {
            wanderMovement();
        }

        // Idle Behavior
        else if (getStatus() == "Idle")
        {
            idleMovement();
        }

        // Deagging Behavior
        else if (getStatus() == "Dragging")
        {
            dragMovement();
        }

        // Bothering Behavior
        else if (getStatus() == "Bothering")
        {
            botherMovement();
        }
    }
}