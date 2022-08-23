using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLocker : MonoBehaviour
{
    public List<UnlockFlag> flags;
    
    [SerializeField] private IntVariable flagIndex;

    [SerializeField] private BoolVariable unlocked;

    private UnlockFlag activeFlag;

    [SerializeField]
    private LayoutElement _layout;

    [SerializeField] private Button characterEnable;

    [SerializeField] private GameObject graphics;

    private void OnEnable()
    {
        unlocked.ValueUpdated += SetRevealStatus;
        flagIndex.ValueUpdated += SetActiveFlag;
    }

    private void OnDisable()
    {
        unlocked.ValueUpdated -= SetRevealStatus;   
        flagIndex.ValueUpdated -= SetActiveFlag;
    }

    private void SetActiveFlag()
    {
        activeFlag = flags[flagIndex.Value];
    }

    private void UpdateLock()
    {
        characterEnable.interactable = activeFlag.Flag;
    }

    private void SetRevealStatus()
    {
        _layout.ignoreLayout = !unlocked.Value;
        graphics.SetActive(unlocked.Value);
    }

    public void onButtonPress()
    {
        activeFlag.onButtonPress.Invoke();
    }
    
    
}
