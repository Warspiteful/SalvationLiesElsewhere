using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Conditional))]

[CanEditMultipleObjects]
public class ConditionalEditor : Editor
{
    private SerializedProperty ConditionalTypeProperty;
    private SerializedProperty boundEventProperty;
    private SerializedProperty boundMultiEventProperty;
    
    private void OnEnable()
    {
        ConditionalTypeProperty = serializedObject.FindProperty("conditionalType");
        boundEventProperty = serializedObject.FindProperty("_EventFlag");
        boundMultiEventProperty = serializedObject.FindProperty("_EventList");
    }
    
    public override void OnInspectorGUI()
    {
      
        
        // Draw the binding type property
        EditorGUILayout.PropertyField(ConditionalTypeProperty);

        // Based on the selected value of the binding type property, draw the
        // appropriate bound property field. Empty fields not in use.
        switch ((ConditionalType)ConditionalTypeProperty.enumValueIndex)
        {
            case ConditionalType.Event:
                EditorGUILayout.PropertyField(boundEventProperty);
                break;
            case ConditionalType.MultiEvent:
                EditorGUILayout.PropertyField(boundMultiEventProperty);
                break;
            case ConditionalType.Constant:
                break;
            default:
                break;
        }
        
       serializedObject.ApplyModifiedProperties();
    }
}
    
