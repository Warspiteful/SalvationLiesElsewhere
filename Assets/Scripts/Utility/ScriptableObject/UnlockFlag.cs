using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]   
public class UnlockFlag : ScriptableObject
{
    public VariableUpdated flagChanged;
    private bool flag;
    public string title;

    public bool Flag
    {
        set
        {
            flag = value;
            flagChanged();
        }
        get
        {
            return flag;
        }
    }
    
    public Conditional condition;
    
    public bool CanBeUnlocked()
    {
        return condition.ConditionCompleted();
    }
    
    public bool Completed;

    public UnityEvent onButtonPress;

}
