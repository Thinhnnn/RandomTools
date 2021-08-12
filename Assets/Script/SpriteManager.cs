using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;

    public List<Character> Characters;

    public List<Sprite> skill1;
    public List<Sprite> skill2;
    
    private void Awake()
    {
        instance = this;
    }
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
