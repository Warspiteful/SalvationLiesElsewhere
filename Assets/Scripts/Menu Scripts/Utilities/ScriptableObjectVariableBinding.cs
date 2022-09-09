using TMPro;
using UnityEngine;

/// <summary>
/// Types of ScriptableObjectVariables that can be bound.
/// </summary>
public enum BindingType { Bool, Float, Int, String };

/// <summary>
/// Binds the value of an asset-level ScriptableObjectVariable to a
/// TextMeshProUGUI component. Whenever the bound variable changes, the
/// TextMeshProUGUI's text value will be updated with the string value of the
/// bound variable. 
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class ScriptableObjectVariableBinding : MonoBehaviour
{
    /// <summary>
    /// Type of variable bound to this display object.
    /// </summary>
    [Tooltip("Type of variable bound to this display object.")]
    [SerializeField] private BindingType bindingType;

    /// <summary>
    /// Boolean variable bound to this display object.
    /// </summary>
    [Tooltip("Boolean variable bound to this display object.")]
    [SerializeField] private BoolVariable boundBool;

    /// <summary>
    /// Float variable bound to this display object.
    /// </summary>
    [Tooltip("Float variable bound to this display object.")]
    [SerializeField] private FloatVariable boundFloat;

    /// <summary>
    /// Int variable bound to this display object.
    /// </summary>
    [Tooltip("Int variable bound to this display object.")]
    [SerializeField] private IntVariable boundInt;

    /// <summary>
    /// String variable bound to this display object.
    /// </summary>
    [Tooltip("String variable bound to this display object.")]
    [SerializeField] private StringVariable boundString;

    /// <summary>
    /// Display text updated to reflect the bound variable.
    /// </summary>
    private TextMeshProUGUI displayText;

    #region MonoBehaviour Methods
    private void Awake()
    {
        displayText = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        switch (bindingType)
        {
            case BindingType.Bool:
                boundBool.VariableUpdated += UpdateDisplayText;
                break;
            case BindingType.Float:
                boundFloat.VariableUpdated += UpdateDisplayText;
                break;
            case BindingType.Int:
                boundInt.VariableUpdated += UpdateDisplayText;
                break;
            case BindingType.String:
                boundString.VariableUpdated += UpdateDisplayText;
                break;
            default:
                break;
        }
    }
    private void Start()
    {
        UpdateDisplayText();
    }
    private void OnDisable()
    {
        switch (bindingType)
        {
            case BindingType.Bool:
                boundBool.VariableUpdated -= UpdateDisplayText;
                break;
            case BindingType.Float:
                boundFloat.VariableUpdated -= UpdateDisplayText;
                break;
            case BindingType.Int:
                boundInt.VariableUpdated -= UpdateDisplayText;
                break;
            case BindingType.String:
                boundString.VariableUpdated -= UpdateDisplayText;
                break;
            default:
                break;
        }
    }
    #endregion

    /// <summary>
    /// Updates the display text to reflect the bound variable.
    /// </summary>
    private void UpdateDisplayText()
    {
        switch (bindingType)
        {
            case BindingType.Bool:
                displayText.text = boundBool.Value.ToString();
                break;
            case BindingType.Float:
                displayText.text = boundFloat.Value.ToString();
                break;
            case BindingType.Int:
                displayText.text = boundInt.Value.ToString();
                break;
            case BindingType.String:
                displayText.text = boundString.Value;
                break;
            default:
                break;
        }
    }
}
