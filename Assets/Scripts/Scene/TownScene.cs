using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class TownScene : IBaseScene
{
    public void Init()
    {
        //맵매니저 Init
        
        //밑에 코드는 테스트용
        GameObject introUI = GameManager.ResourceManager.LoadGameObject("IntroUI");
        ScenesManager scenesManager = GameManager.ScenesManager;
        Button startButton = introUI.GetComponentInChildren<Button>();
        Assert.IsNotNull(startButton);
        startButton.onClick.AddListener(()=> { scenesManager.ChangeSceneSetting(SceneState.IntroScene); scenesManager.ChangeScene(); });
        Assert.IsNotNull(startButton.onClick);
    }
}