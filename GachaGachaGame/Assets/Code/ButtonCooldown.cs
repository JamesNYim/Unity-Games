using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCooldown : MonoBehaviour
{
    public float cooldownTime;

    //On button press
    public void OnButtonPress()
    {
        Debug.Log("Button was clicked. Cooldown time is: " + cooldownTime);
    }
}
