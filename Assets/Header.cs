using System;
using UnityEngine;
using UnityEngine.UI;

public class Header : MonoBehaviour
{
    public event Action OnClick;
    
    public void ButtonInvoke()
    {
        OnClick?.Invoke();
    }
}
