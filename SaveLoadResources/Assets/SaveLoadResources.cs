using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadResources : MonoBehaviour {

    [SerializeField]private int gold;
    public int Gold
    {
        get { return gold; }
    }

    public void SaveResources()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData.kappa");
        SaveData saveData = new SaveData();
        saveData.gold = gold;

        bf.Serialize(file, saveData);
        file.Close();

        Debug.Log(Application.persistentDataPath);
    }

    public void LoadResources()
    {
        if(File.Exists(Application.persistentDataPath + "/SaveData.kappa"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.kappa", FileMode.Open);

            SaveData saveData = (SaveData)bf.Deserialize(file);
            gold = saveData.gold;
            file.Close();
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int gold;
}