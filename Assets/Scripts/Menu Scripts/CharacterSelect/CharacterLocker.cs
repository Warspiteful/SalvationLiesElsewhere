using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLocker : MonoBehaviour
{
    [SerializeField]
    private UnlockFlagSequences sequence;
    
    [SerializeField]
    private LayoutElement _layout;

    [SerializeField] private Button characterEnable;
    
    [SerializeField] private GameObject UnlockButton;

    [SerializeField] private GameObject graphics;
    
    [SerializeField] private TMP_Text description;

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
        if(!sequence.Completed){
            SetActive();
            EnableUnlockButton();
            SetDescription();
        }
        else
        {
            characterEnable.interactable = false;
            UnlockButton.SetActive(false);
        }
    }

    private void SetDescription()
    {
        description.text = sequence.GetDescription();
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

    private void EnableUnlockButton()
    {
        UnlockButton.SetActive(sequence.CanBeUnlocked());
    }

    public void OnButtonPress()
    {
        sequence.GetButtonEvents().Invoke();
    }

    public void UnlockFlag()
    {
        sequence.UnlockFlag();
    }
    
    
}
