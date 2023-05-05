using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideEffect : MonoBehaviour
{
    [SerializeField] private MoveAnimation _skinButtonsMoveAnimation;
    [SerializeField] private MoveAnimation _playerSkinMoveAnimation;
    [SerializeField] private MoveAnimation _botSkinMoveAnimation;
    [SerializeField] private MoveAnimation _playerNickMoveAnimation;
    [SerializeField] private MoveAnimation _botNickMoveAnimation;

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
        _skinButtonsMoveAnimation.PlayOnce();
        _playerSkinMoveAnimation.PlayOnce();
        _playerNickMoveAnimation.PlayOnce();
        _botSkinMoveAnimation.PlayOnce();
        _botNickMoveAnimation.PlayOnce();
    }
}
