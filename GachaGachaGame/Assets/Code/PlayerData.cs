using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int testNum;
    public Hashtable characterInventory;

    public PlayerData(Player player)
    {
        testNum = player.testNum;
        characterInventory = player.characterInventory;
    }
}


