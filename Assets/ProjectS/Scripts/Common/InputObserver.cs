using System;
using UnityEngine;

public class InputObserver : MonoBehaviour
{
    public static InputObserver Instance { get; } = new InputObserver();
    public event Action OnAttackLeft;
    public event Action OnAttackRight;
    private int _hitValue;
    private int _hit;
    
    public int HitDown
    {
        get
        {
            if (Application.isEditor)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Debug.Log("Aキーを押した");
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
    }
    
    public bool CheckKeyDownDecide()
    {
        bool flag = Input.GetKeyDown(KeyCode.A);
        return flag;
    }
    
    public void ClearEvents()
    {
        OnAttackLeft = null;
        OnAttackRight = null;
    }
}
