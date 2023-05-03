using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public const int GameSceneIndex = 1;

    public void LoadGame()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }
}
