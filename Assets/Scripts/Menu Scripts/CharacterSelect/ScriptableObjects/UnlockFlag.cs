using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]   
public class UnlockFlag : ScriptableObject
{

    [SerializeField]
    private bool unlocked;
    
    [SerializeField]
    private EventFlag completed;
    
    public bool isComplete()
    {
        return completed.Value;
    }
    
    public void Unlock()
    {
        unlocked = true;
    }

    public bool IsActive()
    {
        return unlocked;
    }
    
    
    
    public Conditional condition;
    
    public bool CanBeUnlocked()
    {
        return condition.ConditionMet() && !unlocked;
    }

    public UnityEvent onButtonPress;
    
    

}
