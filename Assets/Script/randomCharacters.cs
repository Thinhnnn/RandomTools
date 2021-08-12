using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class randomCharacters : MonoBehaviour
{
    [SerializeField] string characterName;

    [SerializeField] Sprite[] part1, part2, part3, part4, part5, part6;

    [SerializeField] Image pt1, pt2, pt3, pt4, pt5, pt6;

    [SerializeField] Image subpt1, subpt2, subpt3, subpt4, subpt5, subpt6;

    [SerializeField] TextMeshProUGUI txtHP, txtAtk, txtSpeed, txtCritRate, txtCritDmg, txtID, txtSkill;

    [SerializeField] Image HP, ATK, SPEED, CRTR, CRTD;

    int[] extraPoint = { 0, 0, 0, 0, 0 };
    int[] bodyItem = { 0, 0, 0, 0, 0, 0 };
    int[] skills = { 1, 1, 1, 1 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    doRandom();
        //    //Debug.Log(extraPoint[0] + ", " + extraPoint[1] + ", " + extraPoint[2] + ", " + extraPoint[3] + ", " + extraPoint[4]);
        //    Debug.Log(makeID(extraPoint, bodyItem));
        //    //Debug.Log(makeID(extraPoint, bodyItem).Substring(3,3));
        //}
    }

    public void setValueByID(int[] bodyItem, int[] extraPoint, int[] skill)
    {
        pt1.sprite = part1[bodyItem[0]];
        pt2.sprite = part2[bodyItem[1]];
        pt3.sprite = part3[bodyItem[2]];
        pt4.sprite = part4[bodyItem[3]];
        pt5.sprite = part5[bodyItem[4]];
        pt6.sprite = part6[bodyItem[5]];

        subpt1.sprite = part1[bodyItem[0]];
        subpt2.sprite = part2[bodyItem[1]];
        subpt3.sprite = part3[bodyItem[2]];
        subpt4.sprite = part4[bodyItem[3]];
        subpt5.sprite = part5[bodyItem[4]];
        subpt6.sprite = part6[bodyItem[5]];
        this.bodyItem = bodyItem;
        this.extraPoint = extraPoint;
        this.skills = skill;
        setValue();
    }

    public void setValueByName(int[] bodyItem)
    {
        pt1.sprite = part1[bodyItem[0]];
        pt2.sprite = part2[bodyItem[1]];
        pt3.sprite = part3[bodyItem[2]];
        pt4.sprite = part4[bodyItem[3]];
        pt5.sprite = part5[bodyItem[4]];
        pt6.sprite = part6[bodyItem[5]];

        subpt1.sprite = part1[bodyItem[0]];
        subpt2.sprite = part2[bodyItem[1]];
        subpt3.sprite = part3[bodyItem[2]];
        subpt4.sprite = part4[bodyItem[3]];
        subpt5.sprite = part5[bodyItem[4]];
        subpt6.sprite = part6[bodyItem[5]];
        this.bodyItem = bodyItem;
        setValue();
    }

    public void doRandom()
    {
        if (gameObject.active == true)
        {
            randomItem(part1, pt1, 0);
            subpt1.sprite = pt1.sprite;
            randomItem(part2, pt2, 1);
            subpt2.sprite = pt2.sprite;
            randomItem(part3, pt3, 2);
            subpt3.sprite = pt3.sprite;
            randomItem(part4, pt4, 3);
            subpt4.sprite = pt4.sprite;
            randomItem(part5, pt5, 4);
            subpt5.sprite = pt5.sprite;
            randomItem(part6, pt6, 5);
            subpt6.sprite = pt6.sprite;
            extraPoint = subDivide(100);
            skills = randomSkills(100);
            setValue();
            //TakeScreenShot.TakeScreenshot_Static(1920, 1080, makeID(extraPoint, bodyItem));
            TakeScreenShot.TakeScreenshot_Static(1920, 1080, makeIDByName(bodyItem));
            //ScreenCapture.CaptureScreenshot(Application.dataPath + "/Image/ExportImage2/" + makeIDByName(bodyItem) + ".png");
        }
    }

    public int[] randomSkills(int value)
    {
        int[] result = { 1, 1, 1, 1 };
        int randomSkill = Random.Range(1, value + 1);
        result[0] = randomSkill;
        for(int i = 1; i < skills.Length; i++)
        {
            randomSkill = Random.Range(1, value + 1);
            while (exists(result, i, randomSkill))
            {
                randomSkill = Random.Range(1, value + 1);
            }
            result[i] = randomSkill;
        }
        return result;
    }

    public bool exists(int[] skills, int pos, int value)
    {
        bool result = false;
        for (int i = 0; i < pos; i++)
        {
            if (skills[i] == value)
            {
                result = true;
                break;
            }
        }
        return result;
    }

    public void randomItem(Sprite[] listImage, Image obj,int pos)
    {
        int i = Random.Range(0, listImage.Length);
        obj.sprite = listImage[i];
        bodyItem[pos] = i;
    }

    public int[] subDivide(int value)
    {
        int valueLeft = value + 1;
        int randomValue = 0;
        int[] result = { 0, 0, 0, 0, 0 };
        for(int i = 0; i < 4; i++)
        {
            randomValue = Random.Range(0, valueLeft);
            result[i] = randomValue;
            valueLeft -= randomValue;
        }
        result[4] = valueLeft - 1;
        return result;
    }

    public string makeID(int[] subDivide, int[] bodyPart)
    {
        string result = "";
        foreach(int value in bodyPart)
        {
            result += value.ToString();
        }
        foreach(int value in subDivide)
        {
            if (value == 100)
            {
                result += "100";
            }
            else if (value > 9)
            {
                result += ("0" + value.ToString());
            }
            else
            {
                result += ("00" + value.ToString());
            }
        }
        foreach (int value in skills)
        {
            if (value == 100)
            {
                result += "100";
            }
            else if (value > 9)
            {
                result += ("0" + value.ToString());
            }
            else
            {
                result += ("00" + value.ToString());
            }
        }
        return result;
    }

    public string makeIDByName(int[] bodyPart)
    {
        string result = characterName + "_";
        result += "A" + bodyPart[0].ToString() +
                "_B" + bodyPart[1].ToString() +
                "_C" + bodyPart[2].ToString() +
                "_D" + bodyPart[3].ToString() +
                "_E" + bodyPart[4].ToString() +
                "_F" + bodyPart[5].ToString() ;
        return result;
    }

    public void setValue()
    {
        txtHP.text = (200 + extraPoint[0] * 10).ToString();
        HP.fillAmount = (200 + extraPoint[0] * 10) / 1200f;

        txtAtk.text = (20 + extraPoint[1]).ToString();
        ATK.fillAmount = (20 + extraPoint[1]) / 120f;

        txtSpeed.text = (20 + extraPoint[2]).ToString();
        SPEED.fillAmount = (20 + extraPoint[2]) / 120f;

        txtCritRate.text = (10 + extraPoint[3] * 0.5f).ToString() + "%";
        CRTR.fillAmount = (10 + extraPoint[3] * 0.5f) / 100;

        txtCritDmg.text = (50 + extraPoint[4] * 2.5f).ToString() + "%";
        CRTD.fillAmount = (50 + extraPoint[4] * 2.5f) / 300;

        //txtID.text = ("ID: " + makeID(extraPoint, bodyItem));
        txtID.text = ("ID: " + makeIDByName(bodyItem));
        txtSkill.text = "Skill: " + skills[0].ToString() + ", "
                                    + skills[1].ToString() + ", "
                                    + skills[2].ToString() + ", "
                                    + skills[3].ToString();
        //Debug.Log(makeID)
    }
}
