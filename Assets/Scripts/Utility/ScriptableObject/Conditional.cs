using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ConditionalType {Event, Constant, MultiEvent};

[CreateAssetMenu]   
public class Conditional : ScriptableObject
{
    
    [Tooltip("Type of condition bound to this object.")]
    [SerializeField] private ConditionalType conditionalType;
    
    [SerializeField]
    private EventFlag _EventFlag;

    [SerializeField] private List<EventFlag> _EventList;
    
    public string description;

    public bool ConditionMet()
    {
        switch (conditionalType)
        {
            case ConditionalType.Event:
                return _EventFlag.Value;
                break;
            case ConditionalType.MultiEvent:
                foreach (EventFlag flag in _EventList)
                {
                    if (!flag.Value)
                    {
                        return false;
                    }
                }

                return true;
            case ConditionalType.Constant:
                return true;
            default:
                return false;
                break;
        }
    }

    public string GetDescription()
    {
        return "";
    }
    
}
