using System;
using UnityEngine;

public class TickService : MonoBehaviour
{
    public event Action<float> OnTick;

    private void FixedUpdate()
    {
        OnTick?.Invoke(Time.deltaTime);
    }
}
