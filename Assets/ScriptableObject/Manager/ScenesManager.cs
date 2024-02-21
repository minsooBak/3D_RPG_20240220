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
    private IBaseScene _curScene = new IntroScene();
    private IBaseScene _lateScene;
    private SceneState _curState = SceneState.IntroScene;

    private void Awake()
    {
        SceneManager.sceneLoaded += ChangScene;
    }

    public void ChangeSceneSetting<T>(T scene, SceneState state) where T : IBaseScene
    {
        _lateScene = _curScene;
        _curScene = scene;
        _curState = state;
    }

    private void ChangScene(Scene scene, LoadSceneMode mode)
    {
        _curScene.Init();
    }

    public void ChangeScene()
    {
        Assert.IsNotNull(_lateScene);
        _uiManager.Clear();
        SceneManager.LoadScene((int)_curState);
        _lateScene.Exit();
    }
}
