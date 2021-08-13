using UnityEditor;
using UnityEditor.SceneManagement;

namespace _Scripts.Editor
{
    public class ExtendedEditorWindow : EditorWindow
    {
        protected SerializedObject serializedObject;
        protected SerializedProperty currentProperty;

        protected void DrawPropertiesArray(SerializedProperty prop, bool drawChildren)
        {
            foreach (SerializedProperty p in prop)
            {
                if (p.isArray && p.propertyType == SerializedPropertyType.Generic)
                {
                    EditorGUILayout.BeginHorizontal();
                    p.isExpanded = EditorGUILayout.Foldout(p.isExpanded, p.displayName);
                    EditorGUILayout.EndHorizontal();
                    if (p.isExpanded)
                    {
                        EditorGUI.indentLevel++;
                        DrawPropertiesArray(p, drawChildren);
                        EditorGUI.indentLevel--;
                    }
                } else
                {
                    EditorGUILayout.PropertyField(p, drawChildren);
                }
            }
        }

        protected void DrawProperties(SerializedProperty p, bool drawChildren)
        {
            if (p.isArray && p.propertyType == SerializedPropertyType.Generic)
            {
                EditorGUILayout.BeginHorizontal();
                p.isExpanded = EditorGUILayout.Foldout(p.isExpanded, p.displayName);
                EditorGUILayout.EndHorizontal();
                if (p.isExpanded)
                {
                    EditorGUI.indentLevel++;
                    DrawPropertiesArray(p, drawChildren);
                    EditorGUI.indentLevel--;
                }
            }
            else
            {
                EditorGUILayout.PropertyField(p, drawChildren);
            }
        }

        public void Save()
        {
            serializedObject.ApplyModifiedProperties();
        }

        private void OnDisable()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        }
    }
}
