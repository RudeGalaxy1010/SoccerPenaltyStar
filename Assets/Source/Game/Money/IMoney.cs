using System;

public interface IMoney
{
    public event Action<float> Changed;
    public float Value { get; }
}
