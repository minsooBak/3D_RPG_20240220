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