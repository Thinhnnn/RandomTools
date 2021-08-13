using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public List<Character> Characters;

    public List<Sprite> skill1;
    public List<Sprite> skill2;
    public List<Sprite> skill3;
    public List<Sprite> skill4;

    public List<Skill> s1;
    public List<Skill> s2;
    public List<Skill> s3;
    public List<Skill> s4;
    private void Awake()
    {
        instance = this;
    }
}

