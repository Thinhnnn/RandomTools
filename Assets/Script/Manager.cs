using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public List<Transform> Transforms;
    public List<Transform> Character;
    public Image heal;
    public Image dmg;
    public Image speed;
    public Image crt;
    public Image crtDmg;
    public Image skill1;
    public Image skill2;
    public TextMeshProUGUI id;
    [SerializeField] TMP_InputField ammountLoop;
    [SerializeField] TMP_InputField typeOfCharacter;
    private FinalCharacter finalCharacter;
    private void Start()
    {
    }

    public void GetCharacter(int id = 0)
    {
        foreach (var VARIABLE in Character)
        {
            VARIABLE.gameObject.SetActive(false);
        }        
        foreach (var VARIABLE in Transforms)
        {
            VARIABLE.gameObject.SetActive(false);
        }
        finalCharacter = new FinalCharacter(Random(id));
        Transforms[finalCharacter.index].GetChild(1).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p1[finalCharacter.p1 - 1];
        Transforms[finalCharacter.index].GetChild(2).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p2[finalCharacter.p2 - 1];
        Transforms[finalCharacter.index].GetChild(3).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p3[finalCharacter.p3 - 1];
        Transforms[finalCharacter.index].GetChild(4).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p4[finalCharacter.p4 - 1];
        Transforms[finalCharacter.index].GetChild(5).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p5[finalCharacter.p5 - 1];
        Transforms[finalCharacter.index].GetChild(6).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p6[finalCharacter.p6 - 1];
        skill1.sprite = SpriteManager.instance.skill1[finalCharacter.s1 - 1];
        skill2.sprite = SpriteManager.instance.skill1[finalCharacter.s2 - 1];
        Transforms[finalCharacter.index].gameObject.SetActive(true);

        Character[finalCharacter.index].GetChild(0).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p1[finalCharacter.p1 - 1];
        Character[finalCharacter.index].GetChild(1).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p2[finalCharacter.p2 - 1];
        Character[finalCharacter.index].GetChild(2).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p3[finalCharacter.p3 - 1];
        Character[finalCharacter.index].GetChild(3).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p4[finalCharacter.p4 - 1];
        Character[finalCharacter.index].GetChild(4).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p5[finalCharacter.p5 - 1];
        Character[finalCharacter.index].GetChild(5).GetComponent<Image>().sprite = SpriteManager.instance.Characters[finalCharacter.index].p6[finalCharacter.p6 - 1];
        Character[finalCharacter.index].gameObject.SetActive(true);
        
        heal.fillAmount = (finalCharacter.heal * 10 + 200)/ 1000f;
        dmg.fillAmount = (finalCharacter.dmg + 80) / 100f;
        speed.fillAmount = (finalCharacter.speed + 80) / 100f;
        crt.fillAmount = (finalCharacter.crt * 0.5f + 10) / 50f;
        crtDmg.fillAmount = (finalCharacter.crtDmg * 2.5f + 50) / 250f;
        this.id.text = finalCharacter.id;
        /*
         * heal:    200 => 200 + 10 * 80    => 1000
         * dmg:     20 => 20 + 80           => 100
         * speed:   20 => 20 + 80           => 100
         * crt:     10 => 10 + 0.5 * 80     => 50
         * crtDmg   50 => 50 + 2.5 * 80     => 250
         */
        TakeScreenShot.TakeScreenshot_Static(1920,1080, finalCharacter.id);
    }
    private string type;
    private string[] he = new[] {"F", "W", "N", "L", "D"};
    private string Random(int index)
    {
        string id = "";
        int random;
        if (index!= 0)
        {
            random = index;
        }
        else
        {
            random = UnityEngine.Random.Range(0, SpriteManager.instance.Characters.Count);
        }
        id += SpriteManager.instance.Characters[random].name + "_";
        id += he[UnityEngine.Random.Range(0, he.Length)] + "_";
        id += (UnityEngine.Random.Range(0, 5) + 1).ToString() + "_"; //1
        id += (UnityEngine.Random.Range(0, 5) + 1).ToString() + "_"; //2
        id += (UnityEngine.Random.Range(0, 5) + 1).ToString() + "_"; //3
        id += (UnityEngine.Random.Range(0, 5) + 1).ToString() + "_"; //4
        id += (UnityEngine.Random.Range(0, 5) + 1).ToString() + "_"; //5
        id += (UnityEngine.Random.Range(0, 5) + 1).ToString() + "_"; //6
        id += (UnityEngine.Random.Range(0, 20) + 1).ToString() + "_"; //1
        id += (UnityEngine.Random.Range(0, 20) + 1).ToString() + "_"; //2
        int max = UnityEngine.Random.Range(40, 81);
        int temp = UnityEngine.Random.Range(0, max);
        id += temp.ToString() + "_"; //1
        max -= temp;
        temp = UnityEngine.Random.Range(0, max);
        id += temp.ToString() + "_"; //2
        max -= temp;
        temp = UnityEngine.Random.Range(0, max);
        id += temp.ToString() + "_"; //3
        max -= temp;
        temp = UnityEngine.Random.Range(0, max);
        id += temp.ToString() + "_"; //4
        max -= temp;
        temp = UnityEngine.Random.Range(0, max);
        id += temp.ToString(); //5
        return id;
    }
    
    public void doLoopRender()
    {
        //Debug.Log(ammountLoop.text);
        int count;
        Int32.TryParse(ammountLoop.text.Trim(), out count);
        ammountLoop.enabled = false;
        //int count = 10;
        StartCoroutine(render(count));
    }

    IEnumerator render(int count)
    {
        int id;
        Int32.TryParse(typeOfCharacter.text.Trim(), out id);
        if (count <= 0)
        {
            yield break;
        }
        GetCharacter(Mathf.Clamp(id, 0, SpriteManager.instance.Characters.Count));
        TakeScreenShot.TakeScreenshot_Static(1920, 1080, finalCharacter.id);
        count--;
        ammountLoop.text = count.ToString();
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(render(count));
    }

}


public class FinalCharacter
{
    public string id;
    public string character;
    public int index;
    public string he;
    public int p1;
    public int p2;
    public int p3;
    public int p4;
    public int p5;
    public int p6;
    public int s1;
    public int s2;
    public int heal;
    public int dmg;
    public int speed;
    public int crt;
    public int crtDmg;

    public FinalCharacter(string id)
    {
        Read(id);
    }
    private void Read(string id)
    {
        this.id = id;
        string[] gen = id.Split('_');

        if (gen.Length < 15)
        {
            Debug.Log("Wrong ID!");
            return;
        }
        
        character = gen[0];
        switch (character)
        {
            case "DRA":
            {
                index = 0;
                break;
            }
            case "MER":
            {
                index = 1;
                break;
            }
            case "ANC":
            {
                index = 2;
                break;
            }
            case "SHA":
            {
                index = 3;
                break;
            }
        }
        he = gen[1];
        Int32.TryParse(gen[2], out p1);
        Int32.TryParse(gen[3], out p2);
        Int32.TryParse(gen[4], out p3);
        Int32.TryParse(gen[5], out p4);
        Int32.TryParse(gen[6], out p5);
        Int32.TryParse(gen[7], out p6);
        Int32.TryParse(gen[8], out s1);
        Int32.TryParse(gen[9], out s2);
        Int32.TryParse(gen[10], out heal);
        Int32.TryParse(gen[11], out dmg);
        Int32.TryParse(gen[12], out speed);
        Int32.TryParse(gen[13], out crt);
        Int32.TryParse(gen[14], out crt);
    }
}
