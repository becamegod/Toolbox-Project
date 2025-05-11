#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;

using UnityEngine;

using System;
using System.Linq;

public static class EditorHelper
{
    public static void ShowTypesMenuToAdd<T>(List<T> list, bool includeBaseClass = false, Action<T> onSelected = null)
    {
#if UNITY_EDITOR
        var types = Helper.GetAllTypesDerivedFrom<T>();
        if (includeBaseClass) types = Enumerable.Concat(new[] { typeof(T) }, types);
        var menu = new GenericMenu();
        foreach (var type in types)
            menu.AddItem(new GUIContent(type.Name), false, () =>
            {
                T instance = (T)Activator.CreateInstance(type);
                list ??= new();
                list.Add(instance);
                onSelected?.Invoke(instance);
            });
        menu.ShowAsContext();
#endif
    }

    public static void ShowTypesMenu<T>(bool includeBaseClass = false, Action<T> onSelected = null)
    {
#if UNITY_EDITOR
        ShowTypesMenu(typeof(T), includeBaseClass, (object instance) => onSelected?.Invoke((T)instance));
#endif
    }

    public static void ShowTypesMenu(Type type, bool includeBaseClass = false, Action<object> onSelected = null)
    {
#if UNITY_EDITOR
        var types = Helper.GetAllTypesDerivedFrom(type);
        if (includeBaseClass) types = Enumerable.Concat(new[] { type }, types);
        var menu = new GenericMenu();
        foreach (var t in types)
            menu.AddItem(new GUIContent(t.Name.SplitPascalCase()), false, () =>
            {
                var instance = Activator.CreateInstance(t);
                onSelected?.Invoke(instance);
            });
        menu.ShowAsContext();
#endif
    }
}
