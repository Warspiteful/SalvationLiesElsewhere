using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom Editor for the Firearm class.
/// </summary>
[CustomEditor(typeof(ScriptableObjectVariableBinding))]
[CanEditMultipleObjects]
public class ScriptableObjectVariableBindingEditor : Editor
{
    private SerializedProperty bindingTypeProperty;
    private SerializedProperty boundBoolProperty;
    private SerializedProperty boundFloatProperty;
    private SerializedProperty boundIntProperty;
    private SerializedProperty boundStringProperty;

    #region Editor Methods
    private void OnEnable()
    {
        bindingTypeProperty = serializedObject.FindProperty("bindingType");
        boundBoolProperty = serializedObject.FindProperty("boundBool");
        boundFloatProperty = serializedObject.FindProperty("boundFloat");
        boundIntProperty = serializedObject.FindProperty("boundInt");
        boundStringProperty = serializedObject.FindProperty("boundString");
    }
    public override void OnInspectorGUI()
    {
        // Draw Unity-standard disabled script display at top of GUI
        using (new EditorGUI.DisabledScope(true))
            EditorGUILayout.ObjectField("Script",
            MonoScript.FromMonoBehaviour((MonoBehaviour)target),
            GetType(), false);

        // Draw the binding type property
        EditorGUILayout.PropertyField(bindingTypeProperty);

        // Based on the selected value of the binding type property, draw the
        // appropriate bound property field. Empty fields not in use.
        switch ((BindingType)bindingTypeProperty.enumValueIndex)
        {
            case BindingType.Bool:
                EditorGUILayout.PropertyField(boundBoolProperty);
                break;
            case BindingType.Float:
                EditorGUILayout.PropertyField(boundFloatProperty);
                break;
            case BindingType.Int:
                EditorGUILayout.PropertyField(boundIntProperty);
                break;
            case BindingType.String:
                EditorGUILayout.PropertyField(boundStringProperty);
                break;
            default:
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
    #endregion
}
