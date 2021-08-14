using System;
using UnityEditor;
using UnityEngine;

namespace _Scripts.Editor
{
    public class SkillData : ExtendedEditorWindow
    {
        enum Skill
        {
            fire,water,light,dark, nature,
            c1,c2,c3,c4,c5,c6,c7,c8,c9,c10
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
            _skill = Skill.c1;
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            {
                if (GUILayout.Button("Fire"))
                {
                    _skill = Skill.fire;
                    _skillSelected = null;
                }
                if (GUILayout.Button("Water"))
                {
                    _skill = Skill.water;
                    _skillSelected = null;
                }
                if (GUILayout.Button("Light"))
                {
                    _skill = Skill.light;
                    _skillSelected = null;
                }
                if (GUILayout.Button("Dark"))
                {
                    _skill = Skill.dark;
                    _skillSelected = null;
                }
                if (GUILayout.Button("Nature"))
                {
                    _skill = Skill.nature;
                    _skillSelected = null;
                }
                
                if (GUILayout.Button("List skill 1"))
                {
                    _skill = Skill.c1;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 2"))
                {
                    _skill = Skill.c2;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 3"))
                {
                    _skill = Skill.c3;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 4"))
                {
                    _skill = Skill.c4;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 5"))
                {
                    _skill = Skill.c5;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 6"))
                {
                    _skill = Skill.c6;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 7"))
                {
                    _skill = Skill.c7;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 8"))
                {
                    _skill = Skill.c8;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 9"))
                {
                    _skill = Skill.c9;
                    _skillSelected = null;
                }
                if (GUILayout.Button("List skill 10"))
                {
                    _skill = Skill.c10;
                    _skillSelected = null;
                }
            }
            GUILayout.EndHorizontal();
            SerializedProperty skillData;
            switch (_skill)
            {
                case Skill.fire:
                    skillData = serializedObject.FindProperty("fireSkill");
                    _listRound = skillData;
                    break;
                case Skill.water:
                    skillData = serializedObject.FindProperty("waterSkill");
                    _listRound = skillData;
                    break;
                case Skill.light:
                    skillData = serializedObject.FindProperty("lightSkill");
                    _listRound = skillData;
                    break;
                case Skill.dark:
                    skillData = serializedObject.FindProperty("darkSkill");
                    _listRound = skillData;
                    break;
                case Skill.nature:
                    skillData = serializedObject.FindProperty("natureSkill");
                    _listRound = skillData;
                    break;
                case Skill.c1:
                    skillData = serializedObject.FindProperty("c1Skill");
                    _listRound = skillData;
                    break;
                case Skill.c2:
                    skillData = serializedObject.FindProperty("c2Skill");
                    _listRound = skillData;
                    break;
                case Skill.c3:
                     skillData = serializedObject.FindProperty("c3Skill");
                    _listRound = skillData;
                    break;
                case Skill.c4:
                    skillData = serializedObject.FindProperty("c4Skill");
                    _listRound = skillData;
                    break;
                case Skill.c5:
                    skillData = serializedObject.FindProperty("c5Skill");
                    _listRound = skillData;
                    break;
                case Skill.c6:
                    skillData = serializedObject.FindProperty("c6Skill");
                    _listRound = skillData;
                    break;
                case Skill.c7:
                    skillData = serializedObject.FindProperty("c7Skill");
                    _listRound = skillData;
                    break;
                case Skill.c8:
                    skillData = serializedObject.FindProperty("c8Skill");
                    _listRound = skillData;
                    break;
                case Skill.c9:
                    skillData = serializedObject.FindProperty("c9Skill");
                    _listRound = skillData;
                    break;
                case Skill.c10:
                    skillData = serializedObject.FindProperty("c10Skill");
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
