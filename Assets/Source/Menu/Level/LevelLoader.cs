using UnityEngine.SceneManagement;

public class LevelLoader
{
    public const int MenuSceneIndex = 0;
    public const int GameSceneIndex = 1;

    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuSceneIndex);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }
}
