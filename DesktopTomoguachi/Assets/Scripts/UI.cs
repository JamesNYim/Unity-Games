using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject menu;
    public void toggleMenu()
    {
        if (menu != null)
        {
            
            menu.SetActive(!menu.activeSelf);
        }
    }
    public void feedPet()
    {
        Debug.Log("Feeding");
    }

    
}

   
