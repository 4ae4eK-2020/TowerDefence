using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class LoadTowerParams : MonoBehaviour
{
    public T Load<T>(ref T obj, string fileName)
    {
        if (File.Exists(Application.dataPath + "/" +fileName + ".bs"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/" +fileName + ".bs", FileMode.Open);
            obj = (T) binaryFormatter.Deserialize(file);
            file.Close();
            return obj;
        }
        return default(T);
    }
}