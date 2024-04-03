using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public Dictionary<int, SomeInfoData> SomeInfoDataDictionary { get; private set; } = new Dictionary<int, SomeInfoData>();

    public void Init()
    {
        SomeInfoDataDictionary = LoadData<SomeInfo>(nameof(SomeInfo)).MakeDict();
    }

    private T LoadData<T>(string key) where T : ScriptableObject
    {
        T scriptableObject = Managers.Resource.Load<T>($"{key}");
        return scriptableObject;
    }
}

[CreateAssetMenu(fileName = "SomeData", menuName ="Scriptable Object/SomeData")]
public class SomeInfo : ScriptableObject
{
    public SomeInfoData[] dataArray;

    private void OnEnable()
    {
        if (dataArray == null)
        { 
            dataArray = new SomeInfoData[0];
        }
    }

    public Dictionary<int, SomeInfoData> MakeDict()
    {
        Dictionary<int, SomeInfoData> dict = new Dictionary<int, SomeInfoData>();
        foreach (SomeInfoData data in dataArray)
        {
            dict.Add(data.Id, data);
        }

        return dict;
    }
}

[System.Serializable]
public class SomeInfoData
{
    [SerializeField]
    private int _id;
    public int Id { get { return _id; } set { _id = value; } }

    [SerializeField]
    private string _someNote;
    public string SomeNote { get { return _someNote; } set { _someNote = value; } }
}