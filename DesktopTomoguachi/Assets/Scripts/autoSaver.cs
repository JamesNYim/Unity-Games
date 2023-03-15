using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoSaver : MonoBehaviour
{
    public Pet pet;
    // Start is called before the first frame update
    void Start()
    {
        pet.loadData();
    }
}
