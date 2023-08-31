using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private bool isOver;
    
    public bool isUIActive()
    {
        return isOver;
    }
    void OnMouseOver()
    {
        Debug.Log("Mouse entered UI");
        isOver = true;
    }
    void OnMouseExit()
    {
        Debug.Log("Mouse exited UI");
        isOver = false;
    }
}

   
