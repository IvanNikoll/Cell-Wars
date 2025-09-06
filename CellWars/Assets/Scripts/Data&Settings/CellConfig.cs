using System;
using UnityEngine;

public class CellConfig
{
    public int Fighters { get; }
    public int Limit {  get; }
    public OwnerEnum Owner { get; }
    public float AddInterval { get; }
    public Color Color { get; }

    public CellConfig(int fighters, int limit, OwnerEnum owner, float addInterval, Color color)
    {
        if (fighters > 0)
            Fighters = fighters;
        else throw new ArgumentOutOfRangeException(nameof(fighters));
        if (limit > 0)
            Limit = limit;
        else throw new ArgumentOutOfRangeException(nameof(limit));
        Owner = owner;
        if(addInterval > 0)
            AddInterval = addInterval;
        else throw new ArgumentOutOfRangeException(nameof(addInterval));
        Color = color;
    }
}
