using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TimeManager;


public class PetBehavior : MonoBehaviour
{
    // Public Variables
    public GameObject UI;
    public Transform waypoint;
    public Transform[] bounds; 
    public float moveSpeed;
    public float botherMult;
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
    private Vector3 mouseOffset;
    private Vector3 mouseDownPos;
    private Vector3 mouseUpPos;
    private Vector3 direction;
    private TimeManager timeManager = new TimeManager();
    private Rigidbody rigidbody;

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
        dict.Add("Returning", false);
        dict.Add("UI", false);
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
        if (getStatus() == status)
        {
            return;
        }
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

    // Randomly change status based on percent
    private void changeStatus()
    {
        int total = 0;
        Dictionary<string, int> statePercents = new Dictionary<string, int>();
        statePercents.Add("Wandering", 50);
        statePercents.Add("Idle", 0);
        statePercents.Add("Interacting", 0);
        statePercents.Add("Offscreen", 0);
        statePercents.Add("Bothering", 50);
        statePercents.Add("Dragging", 0);
        statePercents.Add("Returning", 0);

        foreach(KeyValuePair<string, int> status in statePercents)
        {
            total += status.Value;
        }
        
        int randomNumber = Random.Range(0, total);
        foreach(KeyValuePair<string, int> status in statePercents)
        {
            if (randomNumber <= status.Value)
            {
                setStatus(status.Key);
                return;
            }
            else
            {
                randomNumber -= status.Value;
            }
        }
    }

    //Move to a position
    private bool moveTowardsWaypoint(float timeToWait, float speed, float offset = .5f)
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint.position, speed * Time.deltaTime);

        // Checking if we reached our destination
        if (Vector2.Distance(transform.position, waypoint.position) < offset) 
        {
            if (currentWaitTime <= 0) // When we have waited long enough
            {
                currentWaitTime = timeToWait;
                return true;
            }
            else // Continue waiting
            {
                currentWaitTime -= Time.deltaTime;
            }
        }
        return false;
    }

    //Get a new wait time
    private void setRandomWaitTime()
    {
        waitTime = Random.Range(minWait, maxWait);
    }
    // For when the pet is wandering
    private void wanderMovement()
    {
        bool hasReached = moveTowardsWaypoint(waitTime, moveSpeed);
        if (hasReached)
        {
            setRandomWaitTime();
            randomWaypoint();
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
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
    }

    // Bother Movement
    private void botherMovement()
    {
        //Need to figure out the z axis for the mouse if i feel like it
        float botherSpeed = moveSpeed * botherMult;
        waypoint.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool hasReached = moveTowardsWaypoint(0, botherSpeed);

    }

    // UI Movement
    private void uiMovement()
    {

    }

    // Off Screen Movement
    private void offscreenMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint.position, moveSpeed * Time.deltaTime);
    }

    // Setting the waypoint()
    private void setWaypoint(Vector2 coords)
    {
        waypoint.position = coords;
    }

    // Finding a new waypoint
    private void randomWaypoint()
    {
        waypoint.position  = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    private void randomOutPoint()
    {
        float xSign = Random.Range(0, 1);
        float ySign = Random.Range(0, 1);
        float randX = Random.Range(maxX, maxX + 100);
        float randY = Random.Range(maxY, maxY + 100);
        if (xSign == 0)
        {
            randX = -randX;
        }
        if (ySign == 0)
        {
            randY = -randY;
        }

        waypoint.position = new Vector2(randX, randY);
        print(waypoint.position);
    }


    // On Game start
    void Start()
    {
        //Initalizing tick system in PetBehavior class
        TickManager.onTick += delegate(object sender, TickManager.OnTickEvent tickEvent) {
            Debug.Log("Tick: " + tickEvent.tick);
        };
        createStatusDict(petStatus); // Initalizing the pet status dictionary 
        
        waitTime = Random.Range(minWait, maxWait); // Setting wait time for wandering
        currentWaitTime = waitTime;
        
        randomWaypoint();
        changeStatus(); 
        rigidbody = GetComponent<Rigidbody>(); 
    }

    // When mouse is over object
    void OnMouseOver()
    {
        //Debug.Log("On Mouse Over");
        mouseOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        setStatus("Idle");
    }

    // When Mouse exits the object
    void OnMouseExit()
    {
        setStatus("Idle");
        changeStatus();
    
    }

    void OnMouseUp()
    {
        changeStatus();
    }

    void OnMouseDrag()
    {
        //Debug.Log("OnMouseDrag");
        setStatus("Dragging");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (UI.activeSelf)
        {
            print("UI is active");
            setWaypoint(UI.transform.position);
            moveTowardsWaypoint(0, moveSpeed);
        }
        // Wandering behavior
        if (getStatus() == "Dragging")
        {
            //Debug.Log("Is dragging");
            dragMovement();
        }

        else if (getStatus() == "Wandering")
        {
            wanderMovement();
        }

        // Idle Behavior
        else if (getStatus() == "Idle")
        {
            idleMovement();
        }        

        // Bothering Behavior
        else if (getStatus() == "Bothering")
        {
            botherMovement();
        }

        // OffScreen Behavior
        else if (getStatus() == "Offscreen")
        {

        }
        
    }
}