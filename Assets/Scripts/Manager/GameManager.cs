using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _i;

    public static GameManager I
    {
        get
        {
            return _i;
        }
    }

    private void Awake()
    {
        if (_i == null) Init();
        else if(_i != this) Destroy(gameObject);
    }

    private void Init()
    {
        _i = this;
        ResourceManager = ScriptableObject.CreateInstance<ResourceManager>();
        UIManager = ScriptableObject.CreateInstance<UIManager>();
        ScenesManager = ScriptableObject.CreateInstance<ScenesManager>();
        DontDestroyOnLoad(gameObject);
    }

    public ResourceManager ResourceManager { get; private set; }
    public UIManager UIManager { get; private set; }
    public ScenesManager ScenesManager { get; private set;}
}
