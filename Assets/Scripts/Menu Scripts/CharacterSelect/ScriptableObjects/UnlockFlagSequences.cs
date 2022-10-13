using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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

    public bool Completed;

    private bool initialized = false;

    [SerializeField] private int index;

   
    public void SetActiveFlag()
    {
        if (!Completed)
        {
            if (activeFlag == null)
            {
                foreach (var flag in sequence.Select((value, i) => new { i, value }))
                {
                    if (!flag.value.isComplete())
                    {
                        activeFlag = flag.value;
                        index = flag.i;
                        break;
                    }
                }
            }
            else if (activeFlag.isComplete())
                {
                    if (index + 1 < sequence.Count)
                    {
                        activeFlag = sequence[index + 1];
                        index += 1;
                    }
                    else
                    {
                        Completed = true;
                    }
                }
        }

        OnDataUpdate?.Invoke();
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
