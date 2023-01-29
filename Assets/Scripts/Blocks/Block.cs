using System;
using UnityEngine;


public abstract class Block : MonoBehaviour
{
    public event Action OnClick;

    private void OnMouseDown()
    {
        OnClick.Invoke();
    }

}
