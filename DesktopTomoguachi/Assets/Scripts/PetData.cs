using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PetData
{
    public int xp;
    public int level;
    public bool hasEaten;

    public PetData(Pet pet)
    {
        xp = pet.xp;
        level = pet.level;
        hasEaten = pet.hasEaten; 
    }
}
