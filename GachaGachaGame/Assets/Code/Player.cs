using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        public Characters characterInventory;
        public int level;
        public string playerName; 

        public Player(string name)
        {
            characterInventory = new Characters();
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

        public void printCharacters()
        {
            characterInventory.printSet();
        }
    }   

}


