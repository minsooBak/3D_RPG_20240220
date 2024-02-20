using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class TownScene : IBaseScene
{
    private GameManager _gameManager = GameManager.I;
    public void Init()
    {
        GameObject introUI = _gameManager.ResourceManager.LoadGameObject("IntroUI");
        ScenesManager scenesManager = _gameManager.ScenesManager;
        scenesManager.ChangeSceneSetting(new IntroScene(), SceneState.IntroScene);
        Button startButton = introUI.GetComponentInChildren<Button>();
        Assert.IsNotNull(startButton);
        startButton.onClick.AddListener(scenesManager.ChangeScene);
        Assert.IsNotNull(startButton.onClick);
    }

    public void Updated()
    {

    }
}
