using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public int xp;
    public int level;
    public bool hasEaten;
    public Dictionary<string, bool> petStatus = new Dictionary<string, bool>();
    
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

        createStatusDict(petStatus); // Creating the dictionary of statuses
    }

    public string getStatus()
    {
        foreach(KeyValuePair<string, bool> status in petStatus)
        {
            if (status.Value)
            {
                return status.Key;
            }
        }
        return null;
    }

    public void clearStatus()
    {
        foreach(KeyValuePair<string, bool> status in petStatus)
        {
            petStatus[status.Key] = false;
        }
    }

    public void setStatus(string status)
    {
        petStatus[status] = true;
    }

    void OnApplicationQuit()
    {
        savePet();
    }

    void Start()
    {
        loadPet();
    }

    private void createStatusDict(Dictionary<string, bool> dict)
    {
        dict.Add("Roaming", false);
        dict.Add("Idle", false);
        dict.Add("Interacting", false);
        dict.Add("Offscreen", false);
        dict.Add("Bothering", false);
        dict.Add("Dragging" false);
    }

}
