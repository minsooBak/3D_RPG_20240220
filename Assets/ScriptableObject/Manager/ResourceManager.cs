using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
using Newtonsoft.Json;

public class ResourceManager : ScriptableObject
{
    public GameObject GetResouce(string path)
    {
        var obj = Resources.Load<GameObject>(path);
        Assert.IsNotNull(obj, $"Prefab Load Faill : {path}");
        return obj;
    }

    private readonly string _dataPath = Application.dataPath + "/Data/";
    public void SaveFile<T>(T data, string path)
    {
        File.WriteAllText(_dataPath + path, JsonConvert.SerializeObject(data, Formatting.Indented));
        Debug.Log($"Save file : {_dataPath + path}");
    }

    public T LoadFile<T>(string path)
    {
        Assert.IsTrue(File.Exists(_dataPath + path), $"Exists File is Null : {_dataPath}{path}");

        string sr = File.ReadAllText(_dataPath + path);
        return JsonConvert.DeserializeObject<T>(sr);
    }

    public bool IsExistsFile(string path)
    {
        return File.Exists(_dataPath + path);
    }
}
