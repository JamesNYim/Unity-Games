using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManager : MonoBehaviour
{

    private const float TICK_INTERVAL = 1f; // Each tick will be spaced one second apart
    private int tick; // Current tick number 
    private float tickTime; // Time till next tick

    // Class to send the tick
    public class OnTickEvent : EventArgs{
        public int tick;
    }
    public static event EventHandler<OnTickEvent> onTick; 
   
    // Start is called before the first frame update
    private void awake()
    {
        tick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tickTime += Time.deltaTime;

        //If we reached the desired tick interval
        if (tickTime >= TICK_INTERVAL)
        {
            tickTime -= TICK_INTERVAL;
            ++tick;
            
            // Sending the tick
            if (onTick != null)
            {
                onTick(this, new OnTickEvent {tick = tick});
            }
        }
    }
}
