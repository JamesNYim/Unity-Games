using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public Character characterInventory;
        public int level;
        public string playerName; 

        public Player(string name)
        {
            characterInventory = new Character();
            level = 0;
            playerName = name;
        }

        public void giveCharacter(string characterName, int amount)
        {
            characterInventory.addCharacter(characterName, amount);
        }

        public void removeCharacter(string characterName, int amount)
        {
            characterInventory.deleteCharacter(characterName, amount);
        } 
    }   

}


