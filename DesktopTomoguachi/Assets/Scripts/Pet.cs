using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    // Pet Data
    public int xp;
    public int level;
    public bool hasEaten;

    // Saving Pet Data
    public void savePet()
    {
        SaveSystem.saveData(this);
    }

    // Loading Pet Data
    public void loadPet()
    {
        PetData data = SaveSystem.loadData();
        xp = data.xp;
        level = data.level;
        hasEaten = data.hasEaten;
    }

    void OnApplicationQuit()
    {
        savePet();
    }

    void Start()
    {
        loadPet();
    }

}
