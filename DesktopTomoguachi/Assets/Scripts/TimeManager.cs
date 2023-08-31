using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager 
{
    public int day;
    public int hour;
    public int minute;
    public int second;
    public int ms;
    
    // Updates the time
    public void updateTime()
    {
        day = System.DateTime.Now.Day;
        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;
        second = System.DateTime.Now.Second;
        ms = System.DateTime.Now.Millisecond;
        //printTime();
    }

    // Returns the day
    public int getDay()
    {
        return day;
    }
    // Returns the hour
    public int getHour()
    {
        return hour;
    }

    // Returns the minute
    public int getMinute()
    {
        return minute;
    }

    // Returns the second
    public int getSecond()
    {
        return second;
    }

    public int getMS()
    {
        return ms;
    }

    // prints the time in "Day:Hour:Minute:Second" format
    public void printTime()
    {
        string timeStr = "" + day + ":" + hour + ":" + minute + ":" + second;
        Debug.Log(timeStr);
    }

    public int[] getElapsedTime(int dayA, int hourA, int minuteA, int secondA)
    {
        int currentDay = getDay();
        int currentHour = getHour();
        int currentMinute = getMinute();
        int currentSecond = getSecond();

        int elapsedDay = currentDay - dayA;
        int elapsedHour = currentHour - hourA;
        int elapsedMinute = currentMinute - minuteA;
        int elapsedSecond = currentSecond - secondA;

        int[] elapsedTime = new int[4];
        elapsedTime[0] = elapsedDay;
        elapsedTime[1] = elapsedHour;
        elapsedTime[2] = elapsedMinute;
        elapsedTime[3] = elapsedSecond;

        return elapsedTime;
    }
}
