using System;
using UnityEditor;
using UnityEngine;

namespace _Scripts.Editor
{
    public class SkillData : ExtendedEditorWindow
    {
        enum Skill
        {
            s1,s2,s3,s4
        }

        private Skill _skill;
        private Vector2 _curPosition;
        private SerializedProperty _listRound;
        
        [MenuItem("MyData/Data Editor &Q")]
        public static void ShowEditor()
        {
            EditorWindow enemyWindow = GetWindow<SkillData>("Skill Setup");
        }
        private void OnEnable()
        {
            DataManager dataManager = FindObjectOfType<DataManager>();
            serializedObject = new SerializedObject(dataManager);
            _skill = Skill.s1;
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            {
                if (GUILayout.Button("List skill 1"))
                {
                    _skill = Skill.s1;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 2"))
                {
                    _skill = Skill.s2;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 3"))
                {
                    _skill = Skill.s3;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 4"))
                {
                    _skill = Skill.s4;
                    _skillSelected = null;
                }
            }
            GUILayout.EndHorizontal();
            SerializedProperty skillData;
            switch (_skill)
            {
                case Skill.s1:
                    skillData = serializedObject.FindProperty("s1");
                    _listRound = skillData;
                    break;
                case Skill.s2:
                    skillData = serializedObject.FindProperty("s2");
                    _listRound = skillData;
                    break;
                case Skill.s3:
                     skillData = serializedObject.FindProperty("s3");
                    _listRound = skillData;
                    break;
                case Skill.s4:
                    skillData = serializedObject.FindProperty("s4");
                    _listRound = skillData;
                    break;
            }
            _curPosition = GUILayout.BeginScrollView(_curPosition, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            {
                GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                {
                    if (_listRound != null)
                    {
                        GUILayout.BeginVertical("box", GUILayout.Width(100));
                        {
                            DrawRound(_listRound);
                        }
                        GUILayout.EndVertical();
                    }

                    if (_skillSelected != null)
                    {
                        GUILayout.BeginVertical("box", GUILayout.Width(200));
                        {
                            GUILayout.BeginHorizontal();
                            {
                                GUILayout.Label("Name", GUILayout.Width(50));
                                _skillSelected.FindPropertyRelative("name").stringValue = GUILayout.TextField(_skillSelected.FindPropertyRelative("name").stringValue, GUILayout.MinWidth(200));
                            }
                            GUILayout.EndHorizontal();
                            
                            GUILayout.BeginHorizontal();
                            {
                                GUILayout.Label("Info", GUILayout.Width(50));
                                _skillSelected.FindPropertyRelative("info").stringValue = GUILayout.TextField(_skillSelected.FindPropertyRelative("info").stringValue,GUILayout.MinWidth(200), GUILayout.Height(200));
                            }
                            GUILayout.EndHorizontal();

                            GUILayout.BeginHorizontal();
                            {
                                GUILayout.Label("Dmg", GUILayout.Width(50));
                                int dmg;
                                Int32.TryParse(GUILayout.TextField(_skillSelected.FindPropertyRelative("dmg").intValue.ToString(), GUILayout.MinWidth(200)), out dmg);
                                _skillSelected.FindPropertyRelative("dmg").intValue = dmg;
                            }
                            GUILayout.EndHorizontal();
                        }
                        GUILayout.EndVertical();
                    }
                    //
                    // if (_waveSelected != null)
                    // {
                    //     GUILayout.BeginVertical("box", GUILayout.ExpandWidth(true));
                    //     {
                    //         DrawPropertiesArray(_waveSelected, true);
                    //     }
                    //     GUILayout.EndVertical();
                    // }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
            
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            {
                if (GUILayout.Button("Save"))
                {
                    serializedObject.ApplyModifiedProperties();
                }
            }
            GUILayout.EndVertical();
        }
        
        private string _skillPath;
        private SerializedProperty _skillSelected;
        private void DrawRound(SerializedProperty se)
        {
            for (int i = 0; i < se.arraySize; i++)
            {
                string name = se.GetArrayElementAtIndex(i).FindPropertyRelative("name").stringValue;
                if (string.IsNullOrEmpty(name))
                {
                    name = se.GetArrayElementAtIndex(i).displayName;
                }

                if (_skillSelected != null && _skillSelected.propertyPath == se.GetArrayElementAtIndex(i).propertyPath)
                {
                    GUI.backgroundColor = Color.gray;
                }
                else
                {
                    GUI.backgroundColor = Color.white;
                }
                
                if (GUILayout.Button(name))
                {
                    _skillPath = se.GetArrayElementAtIndex(i).propertyPath;
                }

                if (!string.IsNullOrEmpty(_skillPath))
                {
                    _skillSelected = serializedObject.FindProperty(_skillPath);
                }
            }
            GUI.backgroundColor = Color.white;
        }
    }
}
