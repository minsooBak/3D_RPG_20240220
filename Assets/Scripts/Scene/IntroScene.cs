using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class IntroScene : IBaseScene
{
    private GameManager _gameManager = GameManager.I;
    public void Init()
    {
        //초기 UI생성
        ResourceManager resourceManager = _gameManager.ResourceManager;
        GameObject introUI = GameObject.Instantiate(resourceManager.GetResouce("IntroUI"));

        //플레이어 데이터 체크 후 맵데이터 세팅 및 버튼 이벤트 변경
        if (resourceManager.IsExistsFile("PlayerData"))
        {
            //던전or마을에 어느위치에 스폰되는지
        }
        else
        {
            //캐릭터 선택씬으로
            ScenesManager scenesManager = _gameManager.ScenesManager;
            scenesManager.ChangeSceneSetting(new IntroScene(), SceneState.TownScene);
            Button startButton = introUI.GetComponentInChildren<Button>();
            Assert.IsNotNull(startButton);
            startButton.onClick.AddListener(scenesManager.ChangeScene);
            Assert.IsNotNull(startButton.onClick);
        }
    }
}
