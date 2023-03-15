using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string filePath = Application.persistentDataPath + "/pet.data";

    public static void saveData(Pet pet)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(filePath, FileMode.Create);

        PetData data = new PetData(pet);

        bf.Serialize(file, data);
        file.Close();
    }

    public static PetData loadData()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(filePath, FileMode.Open);

            PetData data = bf.Deserialize(file) as PetData;
            file.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + filePath);
            return null;
        }
    }
}
