using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Manager : MonoBehaviour
{
    public List<Transform> Transforms;
    public List<Transform> Character;
    public Image heal;
    public Image dmg;
    public Image speed;
    public Image crt;
    public Image crtDmg;
    [Space]
    public TextMeshProUGUI TMPheal;
    public TextMeshProUGUI TMPdmg;
    public TextMeshProUGUI TMPspeed;
    public TextMeshProUGUI TMPcrt;
    public TextMeshProUGUI TMPcrd;
    public TextMeshProUGUI TMPName;

    [Space]

    public Image skill1;
    public Image skill2;
    public Image skill3;
    public Image skill4;
    [Space]
    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;
    public TextMeshProUGUI name3;
    public TextMeshProUGUI name4;
    [Space]
    public TextMeshProUGUI info1;
    public TextMeshProUGUI info2;
    public TextMeshProUGUI info3;
    public TextMeshProUGUI info4;
    [Space]
    public TextMeshProUGUI rateCharacter;
    public TextMeshProUGUI TMP_ID;
    [Space]

    [SerializeField] TMP_InputField ammountLoop;
    [SerializeField] TMP_InputField typeOfCharacter;
    private FinalCharacter finalCharacter;
    private void Start()
    {
    }

    public void RateCharacter(int skill1, int skill2, int skill3, int skill4)
    {
        int sum = 0;
        int rand;
        int[] skills = { skill1, skill2, skill3, skill4 };
        foreach(int sk in skills)
        {
            if (sk < 3)
            {
                rand = UnityEngine.Random.Range(20, 26);
            }
            else if (sk < 6)
            {
                rand = UnityEngine.Random.Range(16, 21);
            }
            else if (sk < 11)
            {
                rand = UnityEngine.Random.Range(11, 16);
            }
            else if (sk < 16)
            {
                rand = UnityEngine.Random.Range(6, 11);
            }
            else
            {
                rand = UnityEngine.Random.Range(0, 6);
            }
            sum += rand;
        }
        rateCharacter.text = sum.ToString();
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
        
        finalCharacter = new FinalCharacter(id, Random(id));

        Debug.Log("Render character id " + finalCharacter.id + " index " + finalCharacter.index);
        TMPName.text = finalCharacter.id;

        //Debug.Log(finalCharacter.index);

        Transforms[finalCharacter.index].GetChild(2).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p1[finalCharacter.p1 - 1];
        Transforms[finalCharacter.index].GetChild(3).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p2[finalCharacter.p2 - 1];
        Transforms[finalCharacter.index].GetChild(4).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p3[finalCharacter.p3 - 1];
        Transforms[finalCharacter.index].GetChild(5).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p4[finalCharacter.p4 - 1];
        Transforms[finalCharacter.index].GetChild(6).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p5[finalCharacter.p5 - 1];
        Transforms[finalCharacter.index].GetChild(7).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p6[finalCharacter.p6 - 1];
        if (Transforms[finalCharacter.index].childCount > 8)
        {
            Transforms[finalCharacter.index].GetChild(8).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p7[finalCharacter.p7 - 1];
        }
        if (Transforms[finalCharacter.index].childCount > 9)
        {
            Transforms[finalCharacter.index].GetChild(9).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p8[finalCharacter.p8 - 1];
        }

        //skill1.sprite = DataManager.instance.skill1[finalCharacter.s1 - 1];
        //skill2.sprite = DataManager.instance.skill2[finalCharacter.s2 - 1];
        //skill3.sprite = DataManager.instance.skill3[finalCharacter.s3 - 1];
        //skill4.sprite = DataManager.instance.skill4[finalCharacter.s4 - 1];

        //RateCharacter(finalCharacter.s1, finalCharacter.s2, finalCharacter.s3, finalCharacter.s4);

        //name1.text = DataManager.instance.mainSkill[finalCharacter.type][finalCharacter.s1 - 1].name;
        //name2.text = DataManager.instance.skills[finalCharacter.index][finalCharacter.s2 - 1].name;
        //name3.text = DataManager.instance.skills[finalCharacter.index][finalCharacter.s3 - 1].name;
        //name4.text = DataManager.instance.skills[finalCharacter.index][finalCharacter.s4 - 1].name;

        //info1.text = DataManager.instance.mainSkill[finalCharacter.type][finalCharacter.s1 - 1].info;
        //info2.text = DataManager.instance.skills[finalCharacter.index][finalCharacter.s2 - 1].info;
        //info3.text = DataManager.instance.skills[finalCharacter.index][finalCharacter.s3 - 1].info;
        //info4.text = DataManager.instance.skills[finalCharacter.index][finalCharacter.s4 - 1].info;

        Transforms[finalCharacter.index].gameObject.SetActive(true);

        Character[finalCharacter.index].GetChild(1).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p1[finalCharacter.p1 - 1];
        Character[finalCharacter.index].GetChild(2).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p2[finalCharacter.p2 - 1];
        Character[finalCharacter.index].GetChild(3).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p3[finalCharacter.p3 - 1];
        Character[finalCharacter.index].GetChild(4).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p4[finalCharacter.p4 - 1];
        Character[finalCharacter.index].GetChild(5).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p5[finalCharacter.p5 - 1];
        Character[finalCharacter.index].GetChild(6).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p6[finalCharacter.p6 - 1];
        if (Character[finalCharacter.index].childCount > 7)
        {
            Character[finalCharacter.index].GetChild(7).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p7[finalCharacter.p7 - 1];
        }
        if (Character[finalCharacter.index].childCount > 8)
        {
            Character[finalCharacter.index].GetChild(8).GetComponent<Image>().sprite = DataManager.instance.Characters[finalCharacter.index].p8[finalCharacter.p8 - 1];
        }
        Character[finalCharacter.index].gameObject.SetActive(true);
        
        //heal.fillAmount = (finalCharacter.heal * 10 + 200)/ 1000f;
        //dmg.fillAmount = (finalCharacter.dmg + 20) / 100f;
        //speed.fillAmount = (finalCharacter.speed + 20) / 100f;
        //crt.fillAmount = (finalCharacter.crt * 0.5f + 10) / 100f;
        //crtDmg.fillAmount = (finalCharacter.crtDmg * 2.5f + 50) / 250f;

        //TMPheal.text = (finalCharacter.heal * 10 + 200).ToString();
        //TMPdmg.text = (finalCharacter.dmg + 80).ToString();
        //TMPspeed.text = (finalCharacter.speed + 80).ToString();
        //TMPcrt.text = (finalCharacter.crt * 0.5f + 10).ToString() + "%";
        //TMPcrd.text = (finalCharacter.crtDmg * 2.5f + 50).ToString() + "%";

        //TMP_ID.text = "ID: " + finalCharacter.id;
        /*
         * heal:    200 => 200 + 10 * 80    => 1000
         * dmg:     20 => 20 + 80           => 100
         * speed:   20 => 20 + 80           => 100
         * crt:     10 => 10 + 0.5 * 80     => 50
         * crtDmg   50 => 50 + 2.5 * 80     => 250
         */
        //TakeScreenShot.TakeScreenshot_Static(1920,1080, finalCharacter.id);
    }

    private string type;
    private string[] he = new[] {"F", "W", "N", "L", "D"};
    private string Random(int index)
    {
        string id = "";
        int random;
        if (index == -1)
        {
            random = UnityEngine.Random.Range(0, DataManager.instance.Characters.Count);
        }
        else
        {
            random = index;
        }
        var dataCharacter = DataManager.instance.Characters;
        id += dataCharacter[random].name + "_";
        //id += he[UnityEngine.Random.Range(0, he.Length)] + "_";

        int randomSourceCount = 11; // character count = 6

        id += dataCharacter[random].p1Name;
        id += (UnityEngine.Random.Range(0, randomSourceCount) + 1).ToString() + "_"; //1
        id += dataCharacter[random].p2Name;
        id += (UnityEngine.Random.Range(0, randomSourceCount) + 1).ToString() + "_"; //2
        id += dataCharacter[random].p3Name;
        id += (UnityEngine.Random.Range(0, randomSourceCount) + 1).ToString() + "_"; //3
        id += dataCharacter[random].p4Name;
        id += (UnityEngine.Random.Range(0, randomSourceCount) + 1).ToString() + "_"; //4
        id += dataCharacter[random].p5Name;
        id += (UnityEngine.Random.Range(0, randomSourceCount) + 1).ToString() + "_"; //5
        id += dataCharacter[random].p6Name;
        id += (UnityEngine.Random.Range(0, randomSourceCount) + 1).ToString(); //6
        if (!dataCharacter[random].p7Name.Trim().Equals(""))
        {
            id += "_" + dataCharacter[random].p7Name;
            id += (UnityEngine.Random.Range(0, randomSourceCount) + 1).ToString(); //7
        }
        if (!dataCharacter[random].p8Name.Trim().Equals(""))
        {
            id += "_" + dataCharacter[random].p8Name;
            id += (UnityEngine.Random.Range(0, randomSourceCount) + 1).ToString(); //8
        }

        /*
        id += (UnityEngine.Random.Range(0, 20) + 1).ToString() + "_"; //1
        int s2 = 0;
        int s3 = 0;
        int s4 = 0;
            
        s2 = UnityEngine.Random.Range(0, 10);
        do
        {
            s3 = UnityEngine.Random.Range(0, 10);
            do
            {
                s4 = UnityEngine.Random.Range(0, 10);
            } while (s3 == s4);
            
        } while (s2 == s3 || s2 == s4);

        s2++;
        s3++;
        s4++;
        
        id += s2 + "_"; //2
        id += s3 + "_"; //3
        id += s4 + "_"; //4
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
        */
        return id;
    }

    public void doLoopRender()
    {
        //Debug.Log(ammountLoop.text);
        int count;
        Int32.TryParse(ammountLoop.text.Trim(), out count);
        if (count==0)
        {
            return;
        }
        ammountLoop.enabled = false;
        //int count = 10;
        StartCoroutine(render(count));
    }

    IEnumerator render(int count)
    {
        int id = 0;
        if (!Int32.TryParse(typeOfCharacter.text.Trim(), out id) || id >= DataManager.instance.Characters.Count)
        {
            //id = -1;
            id = 0;
        }
        Debug.Log("id: " + id);
        GetCharacter(id);
        TakeScreenShot.TakeScreenshot_Static(1920, 1080, finalCharacter.id);
        count--;
        ammountLoop.text = count.ToString();
        if (count <= 0)
        {
            ammountLoop.enabled = true;
            yield break;
        }
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(render(count));
    }
}


public class FinalCharacter
{
    public string id;
    public string character;
    public int index;
    public string he;
    public int type;
    public int p1;
    public int p2;
    public int p3;
    public int p4;
    public int p5;
    public int p6;
    public int p7;
    public int p8; //p8 for pet
    public int s1;
    public int s2;
    public int s3;
    public int s4;
    public int heal;
    public int dmg;
    public int speed;
    public int crt;
    public int crtDmg;

    public FinalCharacter(int index, string id)
    {
        Read(id);
        this.index = index;
        //pet did,'t have random stats
        //RandomStats();
    }

    void RandomStats()
    {
        var characterLst = DataManager.instance.Characters;
        int height = UnityEngine.Random.Range(characterLst[index].minHeight, characterLst[index].maxHeight + 1);
        int weight = UnityEngine.Random.Range(characterLst[index].minWeight, characterLst[index].maxWeight + 1);
        id += "_H" + height;
        id += "_W" + weight;
    }

    private void Read(string id)
    {
        //this.id = id;
        //string[] gen = id.Split('_');

        //if (gen.Length < 15)
        //{
        //    Debug.Log("Wrong ID!");
        //    return;
        //}

        //character = gen[0];
        //switch (character)
        //{
        //    case "BUN":
        //    {
        //        //index = 0;
        //        break;
        //    }
        //    case "HAD":
        //    {
        //        //index = 1;
        //        break;
        //    }
        //    case "IND":
        //    {
        //        //index = 2;
        //        break;
        //    }
        //    case "SHA":
        //    {
        //        //index = 3;
        //        break;
        //    }
        //    case "CEN":
        //    {
        //       // index = 4;
        //        break;
        //    }
        //    case "HAR":
        //    {
        //     //   index = 5;
        //        break;
        //    }
        //    case "GOB":
        //    {
        //       // index = 6;
        //        break;
        //    }
        //    // case "WOL":
        //    // {
        //    //     index = 7;
        //    //     break;
        //    // }
        //    case "MIN":
        //    {
        //     //   index = 7;
        //        break;
        //    }
        //    case "TIT":
        //    {
        //     //   index = 8;
        //        break;
        //    }
        //    case "ANG":
        //    {
        //     //   index = 9;
        //        break;
        //    }
        //}
        //he = gen[1];
        //switch (he)
        //{
        //    case "F":
        //        type = 0;
        //        break;
        //    case "W":
        //        type = 1;
        //        break;
        //    case "D":
        //        type = 2;
        //        break;
        //    case "L":
        //        type = 3;
        //        break;
        //    case "N":
        //        type = 4;
        //        break;

        //}
        //Int32.TryParse(gen[2], out p1);
        //Int32.TryParse(gen[3], out p2);
        //Int32.TryParse(gen[4], out p3);
        //Int32.TryParse(gen[5], out p4);
        //Int32.TryParse(gen[6], out p5);
        //Int32.TryParse(gen[7], out p6);
        //Int32.TryParse(gen[8], out s1);
        //Int32.TryParse(gen[9], out s2);
        //Int32.TryParse(gen[10], out s3);
        //Int32.TryParse(gen[11], out s4);
        //Int32.TryParse(gen[12], out heal);
        //Int32.TryParse(gen[13], out dmg);
        //Int32.TryParse(gen[14], out speed);
        //Int32.TryParse(gen[15], out crt);
        //Int32.TryParse(gen[16], out crtDmg);

        this.id = id;
        string[] gen = id.Split('_');

        if (gen.Length < 6)
        {
            Debug.Log("Wrong ID!");
            return;
        }

        character = gen[0];
        Int32.TryParse((gen[1].Substring(1, gen[1].Length - 1)), out p1);
        Int32.TryParse((gen[2].Substring(1, gen[2].Length - 1)), out p2);
        Int32.TryParse((gen[3].Substring(1, gen[3].Length - 1)), out p3);
        Int32.TryParse((gen[4].Substring(1, gen[4].Length - 1)), out p4);
        Int32.TryParse((gen[5].Substring(1, gen[5].Length - 1)), out p5);
        Int32.TryParse((gen[6].Substring(1, gen[6].Length - 1)), out p6);
        if (gen.Length > 7)
        {
            Int32.TryParse((gen[7].Substring(1, gen[7].Length - 1)), out p7);
        }
        if (gen.Length > 8)
        {
            Int32.TryParse((gen[8].Substring(1, gen[8].Length - 1)), out p8);
        }
    }
}
