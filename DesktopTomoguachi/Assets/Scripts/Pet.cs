using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public int xp;
    public int level;

    public bool hasEaten;

    public void savePet()
    {
        SaveSystem.saveData(this);
    }

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
