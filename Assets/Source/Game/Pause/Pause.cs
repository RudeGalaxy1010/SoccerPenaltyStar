using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private List<IPauseable> _pauseables = new List<IPauseable>();

    public void Add(params IPauseable[] pauseable)
    {
        for (int i = 0; i < pauseable.Length; i++)
        {
            if (_pauseables.Contains(pauseable[i]) == true)
            {
                return;
            }

            _pauseables.Add(pauseable[i]);
        }
    }

    public void SetPause(bool isPause)
    {
        for (int i = 0; i < _pauseables.Count; i++)
        {
            if (isPause)
            {
                _pauseables[i].Pause();
            }
            else
            {
                _pauseables[i].Resume();
            }
        }
    }
}
