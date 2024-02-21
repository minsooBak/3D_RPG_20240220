using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public interface IBaseScene
{
    public abstract void Init();
    public virtual void Exit() 
    {
        GameManager.ResourceManager.UnloadUnusedAssets();
    }
}
public enum SceneState
{
    IntroScene,
    TownScene
}

public class ScenesManager : ScriptableObject
{
    private readonly UIManager _uiManager = GameManager.UIManager;
    private readonly IBaseScene[] _scenes = new IBaseScene[Enum.GetValues(typeof(SceneState)).Length];
    private IBaseScene _curScene;
    private IBaseScene _lateScene;
    private SceneState _curState = SceneState.IntroScene;

    private void Awake()
    {
        SceneManager.sceneLoaded += ChangScene;
        for(int i = 0; i < _scenes.Length; i++)
        {
            Type type = Type.GetType(((SceneState)i).ToString());
            Assert.IsNotNull(type);
            _scenes[i] = (IBaseScene)Activator.CreateInstance(type);
        }
        _curScene = _scenes[0];
    }

    public void ChangeScene(SceneState state)
    {
        _lateScene = _curScene;
        _curScene = _scenes[(int)state];
        _curState = state;
        _uiManager.Clear();
        SceneManager.LoadScene((int)_curState);
    }

    private void ChangScene(Scene scene, LoadSceneMode mode)
    {
        _lateScene?.Exit();
        _curScene.Init();
    }
}
