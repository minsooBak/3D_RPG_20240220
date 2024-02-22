using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class MapScene : IBaseScene
{
    //private MapManager
    public void Init()
    {
        //맵매니저 Init
        GameManager.ResourceManager.LoadGameObject("Terrain");
        GameManager.ResourceManager.LoadGameObject("PlayerObject");
    }
}