using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject ui;

    void OnMouseOver()
    {
        ui.SetActive(true);
    }

    void OnMouseExit()
    {
        ui.SetActive(false);
    }

    void FixedUpdate()
    {
        ui.transform.position = transform.position;
        print("UI: pos: " + ui.transform.position + " | " + transform.position + " : obj pos");
    }
}

   
