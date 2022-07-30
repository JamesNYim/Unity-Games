using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ThePlayer : MonoBehaviour
    {
        public Character characterInventory = new Character();
        public int level;
        public string playerName; 

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


