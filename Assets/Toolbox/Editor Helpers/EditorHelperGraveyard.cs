//using System;
//using System.Linq;
//using System.Reflection;

//using UnityEditor;

//using UnityEditorInternal;

//using UnityEngine;

//public static class EditorHelperGraveyard
//{
//    [Obsolete]
//    public static bool IsExpanded(SerializedProperty property) => InternalEditorUtility.GetIsInspectorExpanded(property.serializedObject.targetObject);

//    // Origin: https://discussions.unity.com/t/query-whether-inspector-is-folded/118298/2
//    private static Type m_InspectorWindowType = null;
//    private static MethodInfo m_GetAllInspectors = null;
//    private static MethodInfo m_GetTracker = null;
//    static EditorHelperGraveyard()
//    {
//        foreach (var T in typeof(EditorApplication).Assembly.GetTypes())
//        {
//            if (T.Name == "InspectorWindow")
//            {
//                m_InspectorWindowType = T;
//                m_GetAllInspectors = T.GetMethod("GetAllInspectorWindows", BindingFlags.Static | BindingFlags.Public);
//                m_GetTracker = T.GetMethod("GetTracker", BindingFlags.Instance | BindingFlags.Public);
//                break;
//            }
//        }
//    }

//    public static EditorWindow[] GetAllInspectorWindows()
//    {
//        var array = m_GetAllInspectors.Invoke(null, null) as EditorWindow[];
//        return array;
//    }

//    public static ActiveEditorTracker GetTracker(EditorWindow aWin)
//    {
//        var tracker = m_GetTracker.Invoke(aWin, null) as ActiveEditorTracker;
//        return tracker;
//    }

//    public static void EnforceExpanded(Type aCustomEditor)
//    {
//        var windows = GetAllInspectorWindows();
//        for (int n = 0; n < windows.Length; n++)
//        {
//            var tracker = GetTracker(windows[n]);
//            var editors = tracker.activeEditors;
//            for (int i = 0; i < editors.Length; i++)
//            {
//                if (editors.GetType() == aCustomEditor)
//                {
//                    int visible = tracker.GetVisible(i);
//                    if (visible == 0)
//                    {
//                        tracker.SetVisible(i, 1);
//                    }
//                }
//            }
//        }
//    }

//    public static bool CheckFold(GameObject gameObject)
//    {
//        var _sceneHierarchyWindowType = typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneHierarchyWindow");
//        var _getExpandedIDs = _sceneHierarchyWindowType.GetMethod("GetExpandedIDs", BindingFlags.NonPublic | BindingFlags.Instance);
//        var _lastInteractedHierarchyWindow = _sceneHierarchyWindowType.GetProperty("lastInteractedHierarchyWindow", BindingFlags.Public | BindingFlags.Static);
//        if (_lastInteractedHierarchyWindow == null)
//        {
//            return false;
//        }
//        var _expandedIDs = _getExpandedIDs.Invoke(_lastInteractedHierarchyWindow.GetValue(null), null) as int[];

//        // Is expanded?
//        return _expandedIDs.Contains(gameObject.GetInstanceID());
//    }
//}
