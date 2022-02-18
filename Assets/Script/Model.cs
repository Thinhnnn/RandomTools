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

    public string p1Name;
    public List<Sprite> p1;
    public string p2Name;
    public List<Sprite> p2;
    public string p3Name;
    public List<Sprite> p3;
    public string p4Name;
    public List<Sprite> p4;
    public string p5Name;
    public List<Sprite> p5;
    public string p6Name;
    public List<Sprite> p6;
    public string p7Name;
    public List<Sprite> p7;
    //p8 for pet
    public string p8Name;
    public List<Sprite> p8;

    public int minHeight;
    public int maxHeight = 210;
    public int minWeight = 50;
    public int maxWeight = 110;
}
