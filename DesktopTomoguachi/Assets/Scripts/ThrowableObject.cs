using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float offset = 0.05f;
    [SerializeField] float force = 100f;
 
    Vector2 lastPosition;
    [SerializeField] float saveDelay = 0.2f;
    [SerializeField] float power = 5f;
    bool nextSave = true;
 
    private bool following;
    Rigidbody rb;
    Vector2 dir;
    bool canBePushed;
 
    // Use this for initialization
    void Start()
    {
        following = false;
        offset += 10;
        lastPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).magnitude <= offset))
        {
            Debug.Log("Following is true");
            following = true;
        }
        if (Input.GetMouseButtonUp(0) && ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).magnitude <= offset))
        {
            Debug.Log("Following is false");
            following = false;
            dir = (Vector2)transform.position - lastPosition;
            canBePushed = true;
        }
 
        if (following)
        {
            transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSpeed);
        }
 
        if (nextSave)
        {
            StartCoroutine("SavePosition");
        }
    }
 
    void FixedUpdate ()
    {
        if (canBePushed)
        {
            canBePushed = false;
            rb.velocity = dir * power;
        }
    }
 
    IEnumerator SavePosition()
    {
        nextSave = false;
        lastPosition = transform.position;
        yield return new WaitForSeconds(saveDelay);
        nextSave = true;
    }
}
