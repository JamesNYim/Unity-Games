using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class Character : MonoBehaviour
    {
        //variables
        private Dictionary<string, int> characterSet;

        //helper functions
        private void addValue(Dictionary<string, int> set, string key, int val)
        {
            set[key] += val;
            return;
        }

        //Creating empty character set
        public Character()
        {
            characterSet = new Dictionary<string, int>();
        }

        //getting the character set
        public Dictionary<string, int> getSet()
        {
            return characterSet;
        }

        //Clearing the character set
        public void clearSet()
        {
            characterSet.Clear();
            return;
        }

        //Checking if character set is empty
        public bool isEmptySet()
        {
            if (characterSet.Count == 0)
            {
                return true;
            }
            return false;
        }

        //Checking if a character is in the character set
        public bool hasCharacter(string characterName)
        {
            return characterSet.ContainsKey(characterName);
        }

        //Adding a character to character set
        public void addCharacter(string characterName, int numOfCharacters) //Can i keep the Dictionart<>?
        {
            //Checking if the character is already in the set
            if (this.hasCharacter(characterName)) 
            {
                this.addValue(characterSet, characterName, numOfCharacters);
            }
            else
            {
                characterSet.Add(characterName, numOfCharacters);
            }
            return;
        }

        //Removing a character from character set
        public bool deleteCharacter(string characterName, int numOfCharacters)
        {
            if (this.hasCharacter(characterName))
            {
                this.addValue(characterSet, characterName, -numOfCharacters);
                return true;
            }
            return false;
        }

        //Printing character set
        public void printSet()
        {
            foreach (KeyValuePair<string, int> character in characterSet)
            {
                Debug.LogFormat("Character Name: {0}, Amount: {1}", character.Key, character.Value);
            }
        }

        

    
    }
}


