using UnityEngine;

public class SlideEffect : MonoBehaviour
{
    [SerializeField] private MoveAnimation[] _moveAnimations;

    [Header("Match Maker")]
    [SerializeField] private MatchMaker _matchMaker;

    private void OnEnable()
    {
        _matchMaker.MatchMakingStarted += OnMatchMakingStarted;
    }

    private void OnDisable()
    {
        _matchMaker.MatchMakingStarted -= OnMatchMakingStarted;
    }

    private void OnMatchMakingStarted()
    {
        for (int i = 0; i < _moveAnimations.Length; i++)
        {
            _moveAnimations[i].PlayOnce();
        }
    }
}
