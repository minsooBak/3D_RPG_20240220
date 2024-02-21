using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class IntroScene : IBaseScene
{
    public void Init()
    {
        //초기 UI생성
        ResourceManager resourceManager = GameManager.ResourceManager;
        GameObject introUI = resourceManager.LoadGameObject("IntroUI");

        //플레이어 데이터 체크 후 맵데이터 세팅 및 버튼 이벤트 변경
        if (resourceManager.IsExistsFile("PlayerData"))
        {
            //던전or마을에 어느위치에 스폰되는지
            //맵매니저의 Init(PlayerData data);
            //인트로 -> 캐릭터선택 or 던전 or 마을 
        }
        else
        {
            //캐릭터 선택씬으로
            ScenesManager scenesManager = GameManager.ScenesManager;
            Button startButton = introUI.GetComponentInChildren<Button>();
            Assert.IsNotNull(startButton);
            startButton.onClick.AddListener(()=> { scenesManager.ChangeSceneSetting(new TownScene(), SceneState.TownScene); scenesManager.ChangeScene(); });
            Assert.IsNotNull(startButton.onClick);
        }
    }
}
