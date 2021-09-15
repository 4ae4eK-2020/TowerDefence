using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveTowerParams : MonoBehaviour
{
    public void Save(object obj, string fileName)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/" +fileName + ".bs");
        binaryFormatter.Serialize(file, obj);
        file.Close();
    }
}
