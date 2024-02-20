using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
using Newtonsoft.Json;

public class ResourceManager : ScriptableObject
{
    private readonly string _dataPath = Application.dataPath + "/Data/";

    public GameObject LoadGameObject(string path)
    {
        var obj = Resources.Load<GameObject>(path);
        Assert.IsNotNull(obj, $"Prefab Load Faill : {path}");
        GameObject result = Instantiate(obj);
        return result;
    }

    public GameObject LoadGameObject(string path, Transform parent)
    {
        var obj = Resources.Load<GameObject>(path);
        Assert.IsNotNull(obj, $"Prefab Load Faill : {path}");
        GameObject result = Instantiate(obj, parent);
        return result;
    }

    public void UnloadUnusedAssets()
    {
        Resources.UnloadUnusedAssets();
    }

    public void SaveToJsonFile<T>(T data, string path)
    {
        File.WriteAllText(_dataPath + path, JsonConvert.SerializeObject(data, Formatting.Indented));
        Debug.Log($"Save file : {_dataPath + path}");
    }

    public T LoadJsonFile<T>(string path)
    {
        Assert.IsTrue(File.Exists(_dataPath + path), $"Exists Json File is Null : {_dataPath}{path}");

        string sr = File.ReadAllText(_dataPath + path);
        return JsonConvert.DeserializeObject<T>(sr);
    }

    public string[,] LoadCSVFile(string path)
    {
        Assert.IsTrue(File.Exists(_dataPath + path), $"Exists CSV File is Null : {_dataPath + path}");
        TextAsset csvData = Resources.Load<TextAsset>(_dataPath + path);
        
        string[] lines = csvData.text.Split('\n');

        string[] tempArr = lines[0].Split(',');
        string[,] data = new string[lines.Length, tempArr.Length];
        for(int i = 0; i < lines.Length; i++)
        {
            string[] col = lines[i].Split(',');
            for(int j = 0; j < col.Length; i++)
            {
                data[i, j] = col[j];
            }
        }
        Assert.IsTrue(data.GetLength(0) > 0, $"CSV Data is Null : {lines.Length}");

        return data;
    }

    public bool IsExistsFile(string path)
    {
        return File.Exists(_dataPath + path);
    }
}
