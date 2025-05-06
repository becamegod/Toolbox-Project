using System;

using UnityEngine;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ShowIfAttribute : PropertyAttribute
{
    public string ConditionField = "";
    public bool HideInInspector = true;
    public object Value;

    public ShowIfAttribute(string conditionalSourceField)
    {
        ConditionField = conditionalSourceField;
    }

    public ShowIfAttribute(string conditionalSourceField, bool hideInInspector)
    {
        ConditionField = conditionalSourceField;
        HideInInspector = hideInInspector;
    }

    public ShowIfAttribute(string conditionalSourceField, object value)
    {
        ConditionField = conditionalSourceField;
        Value = value;
    }
}
