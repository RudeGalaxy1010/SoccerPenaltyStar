using UnityEngine;

public class BonusGates : MonoBehaviour
{
    [SerializeField] private Gates _gates;
    [SerializeField] private ReverseTimer _timer;

    public Gates Gates => _gates;
    public ReverseTimer Timer => _timer;
}
