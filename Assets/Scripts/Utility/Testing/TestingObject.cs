using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TestingObject : ScriptableObject
{
    public string testingText;
    public void Validate()
    {
        Debug.Log(testingText);
    }
}
