using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]   
public class UnlockFlagSequences : ScriptableObject
{
    [SerializeField]
    private List<UnlockFlag> sequence;

    [SerializeField]
    private UnlockFlag activeFlag;

    public VariableUpdated OnDataUpdate;

    [SerializeField]
    private Conditional RevealCondition;
    
    public VariableUpdated RevealUpdated;



    public void SetActiveFlag()
    {
        foreach (UnlockFlag flag in sequence)
        {
            Debug.Log(flag.name + ": " + flag.isComplete());
            if (!flag.isComplete())
            {
      
                
                activeFlag = flag;
                break;
            }
        }
        
        if(activeFlag != null){
            OnDataUpdate?.Invoke();
        }
    }

    public bool CanBeUnlocked()
    {
        return activeFlag.CanBeUnlocked();
    }

    public void UnlockFlag()
    {
        activeFlag.Unlock();
        OnDataUpdate?.Invoke();
    }

    public bool GetActive()
    {
        return activeFlag.IsActive();
    }

    public UnityEvent GetButtonEvents()
    {
        return activeFlag.onButtonPress;
    }

    public bool CanReveal()
    {
        return RevealCondition.ConditionMet();
    }

    public String GetDescription()
    {
        return activeFlag.condition.GetDescription();
    }



}
