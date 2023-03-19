using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Transform petTransform;

    void FixedUpdate()
    {
        transform.position = petTransform.position;
        print(transform.position);
    }
}
   
