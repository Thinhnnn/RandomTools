using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skill
{
    public string name;
    public string info;
    public int dmg;
}
[Serializable]
public class Character
{
    public string name;
    public List<Sprite> p1;
    public List<Sprite> p2;
    public List<Sprite> p3;
    public List<Sprite> p4;
    public List<Sprite> p5;
    public List<Sprite> p6;
}
