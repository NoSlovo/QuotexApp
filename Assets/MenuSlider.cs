using DG.Tweening;
using UnityEngine;

public class MenuSlider : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    private float _rectPositionX = -1200;

    public void Open() => _rectTransform.DOMoveX(0, 1f);


    public void Close() => _rectTransform.DOMoveX(_rectPositionX, 1f);
}