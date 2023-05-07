using System;
using UnityEngine;

public class SkinParts : MonoBehaviour
{
    public event Action PartChanged;

    [SerializeField] private SkinPart[] _skinParts;

    private int _currentPartIndex;

    public SkinPart CurrentPart => _skinParts[_currentPartIndex];

    public void SetPart(int index)
    {
        _currentPartIndex = index;

        for (int i = 0; i < _skinParts.Length; i++)
        {
            if (i == _currentPartIndex)
            {
                _skinParts[i].gameObject.SetActive(true);
                continue;
            }

            _skinParts[i].gameObject.SetActive(false);
        }

        PartChanged?.Invoke();
    }

    public void SetNextPart()
    {
        _currentPartIndex++;

        if (_currentPartIndex >= _skinParts.Length)
        {
            _currentPartIndex = 0;
        }

        SetPart(_currentPartIndex);
    }

    public void SetPreviousPart()
    {
        _currentPartIndex--;

        if (_currentPartIndex < 0)
        {
            _currentPartIndex = _skinParts.Length - 1;
        }

        SetPart(_currentPartIndex);
    }

    public void SetRandom(int[] availableIndexes = null)
    {
        if (availableIndexes != null)
        {
            SetPart(availableIndexes[UnityEngine.Random.Range(0, availableIndexes.Length)]);
            return;
        }

        SetPart(UnityEngine.Random.Range(0, _skinParts.Length));
    }
}
