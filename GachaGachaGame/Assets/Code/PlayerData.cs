using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerData 
    {
        public string playerName;
        public int level;
        public Dictionary<string, int> characterInventory;

        public PlayerData(Player player)
        {
            level = player.level;
            playerName = player.playerName;
            characterInventory = player.characterInventory.getSet();
        }
    } 
}  




