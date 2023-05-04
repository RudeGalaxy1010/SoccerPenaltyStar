using System;
using UnityEngine;

public class SkinCustomization : MonoBehaviour
{
    private const string CustomizationPartTypeExceptionMessage = "Customization part type is not defined";

    [SerializeField] private GameObject[] _mainBodies;
    [SerializeField] private GameObject[] _bodyPats;
    [SerializeField] private GameObject[] _eyes;
    [SerializeField] private GameObject[] _gloves;
    [SerializeField] private GameObject[] _headParts;
    [SerializeField] private GameObject[] _mouthes;
    [SerializeField] private GameObject[] _noses;
    [SerializeField] private GameObject[] _hats;
    [SerializeField] private GameObject[] _tails;

    private SkinCustomizationData _skinCustomizationData;

    public void Apply(SkinCustomizationData skinCustomizationData)
    {
        _skinCustomizationData = skinCustomizationData;
        ApplyAll(_skinCustomizationData);
    }

    public void ResetAll()
    {
        _skinCustomizationData.Reset();
        ApplyAll(_skinCustomizationData);
    }

    private void ApplyAll(SkinCustomizationData skinCustomizationData)
    {
        SetPart(_mainBodies, skinCustomizationData.ColorIndex);
        SetPart(_bodyPats, skinCustomizationData.BodyPartsIndex);
        SetPart(_eyes, skinCustomizationData.EyesIndex);
        SetPart(_gloves, skinCustomizationData.GlovesIndex);
        SetPart(_headParts, skinCustomizationData.HeadPartsIndex);
        SetPart(_mouthes, skinCustomizationData.MouthesIndex);
        SetPart(_noses, skinCustomizationData.NosesIndex);
        SetPart(_hats, skinCustomizationData.HatsIndex);
        SetPart(_tails, skinCustomizationData.TailsIndex);
    }

    public void SetPreviousPart(CustomizationPart customizationPart)
    {
        int roundedIndex = -1;

        switch (customizationPart)
        {
            case CustomizationPart.Color:
                roundedIndex = GetRoundIndex(--_skinCustomizationData.ColorIndex, 0, _mainBodies.Length - 1);
                _skinCustomizationData.ColorIndex = roundedIndex;
                break;
            case CustomizationPart.Body:
                roundedIndex = GetRoundIndex(--_skinCustomizationData.BodyPartsIndex, 0, _bodyPats.Length - 1);
                _skinCustomizationData.BodyPartsIndex = roundedIndex;
                break;
            case CustomizationPart.Eyes:
                roundedIndex = GetRoundIndex(--_skinCustomizationData.EyesIndex, 0, _eyes.Length - 1);
                _skinCustomizationData.EyesIndex = roundedIndex;
                break;
            case CustomizationPart.Gloves:
                roundedIndex = GetRoundIndex(--_skinCustomizationData.GlovesIndex, 0, _gloves.Length - 1);
                _skinCustomizationData.GlovesIndex = roundedIndex;
                break;
            case CustomizationPart.Head:
                roundedIndex = GetRoundIndex(--_skinCustomizationData.HeadPartsIndex, 0, _headParts.Length - 1);
                _skinCustomizationData.HeadPartsIndex = roundedIndex;
                break;
            case CustomizationPart.Mouth:
                roundedIndex = GetRoundIndex(--_skinCustomizationData.MouthesIndex, 0, _mouthes.Length - 1);
                _skinCustomizationData.MouthesIndex = roundedIndex;
                break;
            case CustomizationPart.Nose:
                roundedIndex = GetRoundIndex(--_skinCustomizationData.NosesIndex, 0, _noses.Length - 1);
                _skinCustomizationData.NosesIndex = roundedIndex;
                break;
            case CustomizationPart.Hat:
                roundedIndex = GetRoundIndex(--_skinCustomizationData.HatsIndex, 0, _hats.Length - 1);
                _skinCustomizationData.HatsIndex = roundedIndex;
                break;
            case CustomizationPart.Tail:
                roundedIndex = GetRoundIndex(--_skinCustomizationData.TailsIndex, 0, _tails.Length - 1);
                _skinCustomizationData.TailsIndex = roundedIndex;
                break;
            default:
                throw new ArgumentException(CustomizationPartTypeExceptionMessage);
        }

        ApplyAll(_skinCustomizationData);
    }

    public void SetNextPart(CustomizationPart customizationPart)
    {
        int roundedIndex = -1;

        switch (customizationPart)
        {
            case CustomizationPart.Color:
                roundedIndex = GetRoundIndex(++_skinCustomizationData.ColorIndex, 0, _mainBodies.Length - 1);
                _skinCustomizationData.ColorIndex = roundedIndex;
                break;
            case CustomizationPart.Body:
                roundedIndex = GetRoundIndex(++_skinCustomizationData.BodyPartsIndex, 0, _bodyPats.Length - 1);
                _skinCustomizationData.BodyPartsIndex = roundedIndex;
                break;
            case CustomizationPart.Eyes:
                roundedIndex = GetRoundIndex(++_skinCustomizationData.EyesIndex, 0, _eyes.Length - 1);
                _skinCustomizationData.EyesIndex = roundedIndex;
                break;
            case CustomizationPart.Gloves:
                roundedIndex = GetRoundIndex(++_skinCustomizationData.GlovesIndex, 0, _gloves.Length - 1);
                _skinCustomizationData.GlovesIndex = roundedIndex;
                break;
            case CustomizationPart.Head:
                roundedIndex = GetRoundIndex(++_skinCustomizationData.HeadPartsIndex, 0,_headParts.Length - 1);
                _skinCustomizationData.HeadPartsIndex = roundedIndex;
                break;
            case CustomizationPart.Mouth:
                roundedIndex = GetRoundIndex(++_skinCustomizationData.MouthesIndex, 0, _mouthes.Length - 1);
                _skinCustomizationData.MouthesIndex = roundedIndex;
                break;
            case CustomizationPart.Nose:
                roundedIndex = GetRoundIndex(++_skinCustomizationData.NosesIndex, 0, _noses.Length - 1);
                _skinCustomizationData.NosesIndex = roundedIndex;
                break;
            case CustomizationPart.Hat:
                roundedIndex = GetRoundIndex(++_skinCustomizationData.HatsIndex, 0, _hats.Length - 1);
                _skinCustomizationData.HatsIndex = roundedIndex;
                break;
            case CustomizationPart.Tail:
                roundedIndex = GetRoundIndex(++_skinCustomizationData.TailsIndex, 0, _tails.Length - 1);
                _skinCustomizationData.TailsIndex = roundedIndex;
                break;
            default:
                throw new ArgumentException(CustomizationPartTypeExceptionMessage);
        }

        ApplyAll(_skinCustomizationData);
    }

    private int GetRoundIndex(int index, int minValue, int maxValue)
    {
        if (index > maxValue)
        {
            return minValue;
        }
        else if (index < minValue)
        {
            return maxValue;
        }

        return index;
    }

    private void SetPart(GameObject[] parts, int index)
    {
        for (int i = 0; i < parts.Length; i++)
        {
            if (i == index)
            {
                if (parts[i] != null)
                {
                    parts[i].SetActive(true);
                }

                continue;
            }

            if (parts[i] != null)
            {
                parts[i].SetActive(false);
            }
        }
    }
}
