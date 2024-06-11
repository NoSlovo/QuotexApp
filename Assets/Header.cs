using System;
using UnityEngine;
using UnityEngine.UI;


public class Header : MonoBehaviour
{
    [SerializeField] private Button _button;
    public event Action OnClick;
    
    public void ButtonInvoke()
    {
        OnClick?.Invoke();
    }
}
