using System;
using UnityEngine;

public class InteractiveBtn : MonoBehaviour
{
    private Action _onClick = null;

    public void ConfigureOnClickXR(Action onClick)
    {
        _onClick = onClick;
    }

    public void OnPointerClickXR()
    {
        _onClick?.Invoke();
    }

}
