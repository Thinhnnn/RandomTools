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

    public List<List<Skill>> mainSkill = new List<List<Skill>>();
    public List<Skill> fireSkill;
    public List<Skill> waterSkill;
    public List<Skill> lightSkill;
    public List<Skill> darkSkill;
    public List<Skill> natureSkill;

    public List<List<Skill>> skills = new List<List<Skill>>();
    public List<Skill> c1Skill;
    public List<Skill> c2Skill;
    public List<Skill> c3Skill;
    public List<Skill> c4Skill;
    public List<Skill> c5Skill;
    public List<Skill> c6Skill;
    public List<Skill> c7Skill;
    public List<Skill> c8Skill;
    public List<Skill> c9Skill;
    public List<Skill> c10Skill;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mainSkill.Add(fireSkill);
        mainSkill.Add(waterSkill);
        mainSkill.Add(lightSkill);
        mainSkill.Add(darkSkill);
        mainSkill.Add(natureSkill);
        
        skills.Add(c1Skill);
        skills.Add(c2Skill);
        skills.Add(c3Skill);
        skills.Add(c4Skill);
        skills.Add(c5Skill);
        skills.Add(c6Skill);
        skills.Add(c7Skill);
        skills.Add(c8Skill);
        skills.Add(c9Skill);
        skills.Add(c10Skill);
    }
}

