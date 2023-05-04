using System;
using UnityEngine;

public class BonusGates : MonoBehaviour
{
    public event Action GoalScored;

    [SerializeField] private Gates _gates;
    [SerializeField] private ReverseTimer _timer;

    public Gates Gates => _gates;
    public ReverseTimer Timer => _timer;
}
