using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private LevelLoader _levelLoader;

    public void Construct(LevelLoader levelLoader)
    {
        _levelLoader = levelLoader;
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        _levelLoader.LoadGame();
    }
}
