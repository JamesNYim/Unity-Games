using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject ui;
    public GameObject Pet;

    public void showUI()
    {
        ui.SetActive(true);
        print("Showing UI");
    }

    public void closeUI()
    {
        print("Closing UI");
        ui.SetActive(false);
    }

    void OnMouseOver()
    {
        showUI();
        print("Mouse over UI");
    }

    void OnMouseExit()
    {
        closeUI();
        print("Mouse exited UI");
    }

    void FixedUpdate()
    {
        ui.transform.position = transform.position;
        print("UI: pos: " + ui.transform.position + " | " + transform.position + " : obj pos");
    }
}

   
