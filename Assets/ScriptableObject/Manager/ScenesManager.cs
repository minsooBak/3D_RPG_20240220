using UnityEngine;
using UnityEngine.SceneManagement;

public interface IBaseScene
{
    public abstract void Init();
    public virtual void Updated() { }
    public virtual void Exit() { }
}
public enum SceneState
{
    IntroScene,
    TownScene
}

public class ScenesManager : ScriptableObject
{
    private readonly UIManager _uiManager = GameManager.I.UIManager;
    private IBaseScene _curScene = new IntroScene();
    private SceneState _curState = SceneState.IntroScene;

    private void Awake()
    {
        SceneManager.sceneLoaded += ChangScene;
    }

    public void ChangeSceneSetting<T>(T scene, SceneState state) where T : IBaseScene
    {
        _curScene.Exit();
        _curScene = scene;
        _curState = state;
    }

    private void ChangScene(Scene scene, LoadSceneMode mode)
    {
        _uiManager.Clear();
        _curScene.Init();
    }

    public void Updated()
    {
        _curScene.Updated();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene((int)_curState);
    }
}
