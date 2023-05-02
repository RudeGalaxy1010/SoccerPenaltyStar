using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string NegativeScoreExceptionMessage = "Can't add negative value to score";
    private int _score;

    public void AddScore(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException(NegativeScoreExceptionMessage);
        }

        _score += value;
    }
}
