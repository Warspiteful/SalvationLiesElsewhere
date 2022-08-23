using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLocker : MonoBehaviour
{
    [SerializeField]
    private UnlockFlagSequences sequence;
    
    [SerializeField]
    private LayoutElement _layout;

    [SerializeField] private Button characterEnable;

    [SerializeField] private GameObject graphics;

    private void Start()
    {
        SetRevealStatus();
    }

    private void OnEnable()
    {
        sequence.RevealUpdated += SetRevealStatus;
        sequence.OnDataUpdate += UpdateSettings;
    }

    private void OnDisable()
    {
        sequence.RevealUpdated -= SetRevealStatus;   
        sequence.OnDataUpdate -= UpdateSettings;
    }

    private void UpdateSettings()
    {
        SetActive();
    }

    private void SetDescription()
    {
        
    }

    private void SetActive()
    {
        characterEnable.interactable = sequence.GetActive();
    }
    
    private void SetRevealStatus()
    {
        _layout.ignoreLayout = !sequence.CanReveal();
        graphics.SetActive(sequence.CanReveal());
    }

    public void OnButtonPress()
    {
        sequence.GetButtonEvents().Invoke();
    }
    
    
}
